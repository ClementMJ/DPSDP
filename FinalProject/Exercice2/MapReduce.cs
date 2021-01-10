﻿using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FinalProject
{
    public class MapReduce
    {
		private string text;
		private ConcurrentBag<KeyValuePair<string, int>> valuePairs; // It's a thread-safe collection of objects
		private ConcurrentDictionary<string, List<int>> suffled; // Ìt's a thread-safe collection of key/value pairs
		private ConcurrentDictionary<string, int> reduce; // Ìt's a thread-safe collection of key/value pairs

		public MapReduce(string text)
		{
			this.text = text; // Text is the text in the file that we work on
			Mapping(); // Map procedure of the MapReduce Process
			Shuffling(); // Shuffle procedure of the MapReduce Process
			Reduce(); // Reduce procedure of the MapReduce Process
		}

		public void Mapping()
        {
			this.valuePairs = new ConcurrentBag<KeyValuePair<string, int>>(); // Save into a concurrent bag the key value pair
			Parallel.ForEach(this.text.Split(' ', ',','.','\n'), (word) => // Split the text within words at each ' ',','...
			  {
				  valuePairs.Add(new KeyValuePair<string, int>(word.ToLower(),1)); // for each words, add the word within the concurrent bag and set his value to 1
			  }); 
		}

		public void Shuffling()
        {
			this.suffled = new ConcurrentDictionary<string, List<int>>(); // Save into a concurrent dictionnary
			Parallel.ForEach(this.valuePairs, (word) => // Iterate on each value in the concurrent bag
			{
				if (this.suffled.ContainsKey(word.Key)) // If the concurrent dictionnary contains the value (here a word)
                {
					this.suffled[word.Key].Add(1); // Add another one in the value associate to the word key, it means -> thisword : 1 1 ...
                }
                else
				{	// At the first time the word is not contains by the dictionnary 
					this.suffled.TryAdd(word.Key, new List<int> { 1 }); // Add the word within with a one to the value -> thisword : 1
                }
			});
		}

		public void Reduce()
		{
			this.reduce = new ConcurrentDictionary<string, int>();
			Parallel.ForEach(this.suffled, (pair) =>
			{
				int nb = 0;
				Parallel.ForEach(pair.Value, (value) =>
				 {
					 nb += value;
				 });
				this.reduce.TryAdd(pair.Key, nb);
			});
		}


        public override string ToString()
        {
			string result = "";
			Parallel.ForEach(this.reduce, (entry) =>
			{
				Dictionary<string,int> words= new Dictionary<string, int>();
				words.Add(entry.Key, entry.Value);

				Parallel.ForEach(words, (pair) =>
				{
					result += string.Format(pair.Key + " : " + pair.Value + "\n");
				});
			});
			return result;
		}

	}
}
