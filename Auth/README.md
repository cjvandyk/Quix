Coding Conventions

1. Method names are in camel case with the first letter in upper case e.g.
		public string MethodName(string argstring)
2. Variable names are camel case with the first letter in lower case e.g.
		string myString;
3. Parameter names are all lowercase regardless of word length e.g.
		public string MethodName(string arg1, string argstringname)
4. Method definitions list parameter(s) (if any) on subsequent, indented lines e.g.
		public string MethodName(
			string arg1, 
			string argstringname)
	or
		public string MethodName(
			string arg1)
5. Method calls list parameters on subsequent, indented lines IF more than one
	parameter is being passed e.g.
		myString = MethodName(
			anotherString,
			yetAnotherString);
	or
		myString = MethodName(anotherString);
6. Try and keep lines shorter than 80 chars.