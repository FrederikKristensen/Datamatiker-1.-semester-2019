using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lplplp.Common
{
	class NumberGenerator
	{

		private Random _generator;

		public NumberGenerator()
		{
			_generator = new Random();
		}

		// Returnerer en tilfældig værdi mellem tallene "Min" og Max" (begge inklusive) 

		public int Next(int min, int max)
		{
			int value = min + _generator.Next(max - min + 1);
			return value;
		}
	}
}

