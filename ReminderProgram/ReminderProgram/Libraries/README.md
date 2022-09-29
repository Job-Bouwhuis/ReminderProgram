# SnowLibrary
 A library made for all Snows Needs
 Should you, another user wish for a specific feature, then be sure to relay it to me. i can always try to add it.


# Serializer
	SnowSerializer.Serialize<T>(T data); serializes a single class object
	SnowSerializer.SerializeList<T>(List<T> data); serializes a list of class objects 
	SnowSerializer.SerializeArray<T>(T[] data); serializes an array of class objects
	SnowSerializer.Deserialize<T>(string data, includePrivateFields); serializing makes it into a string which this method turns back into the object it was. where T represents the class it should deserialize into
	SnowSerializer.DeserializeArray<T>(string data, includePrivateFields); same as normal deserialize only this turns the end result in a array of the object T
	SnowSerializer.DeserializeList<T>(string data, includePrivateFields); again same as the normal deserialize, but this turns the end result into a list of object T
	[ExcludeFromSerialization] attribute for fields. it does exactly as the name emplies
	[IncludeWithSerialization] attribute for propperties. it does exactly as the name emplies
	[IncludeAllProperties] attribute for classes and structs. it tells the serializer to include the properties within the class or struct even if the properties do not have the [IncludeWithSerialization] attribute
	[IncludePrivateFields] attribute for classes and structs. it tells the serializer to include all private fields within the class or struct even if the passed setting states to ignore private fields
	the speeds of the serializing and de-serializing depends on the CPU of the machine its executed on. the total memory usage will in most cases not exceed 500MB

# Fields/propperties supported by the serializer:
	Standard Fields:
		bool, byte, sbyte, char, decimal, double, float, int, uint, long, ulong, short, ushort, string, DateTime, TimeOnly, DateOnly, TimeSpan
		class objects containing any of the above stated variables, another class object, or any field stated below
	fields other than standard stuff:
		* list<all standard fields> 
		* array[all standard fields] (no multidimentional arrays are supported)
		* dictionary<all standard fields, all standard fields>
		* Events with no arguments or return types. it stores the refference to all the methods it has. meaning annonymous methods wont work, neither will any top level method. 
		  further, all methods must follow standard Event rules. public void EventMethod(object? o, EventArgs e) object can be replaced with the dynamic keyword to have a usable object passed through
		* Nullable<T> of any of the standard fields stated above.
		* any Enum

# Encrypter
	new Encrypter(new EncrypterSetting(ScrambleConfiguration setting1, ScrambleConfiguration setting2, ScrambleConfiguration setting3, int offset, int moveNext)); settings indicate the scramble ways, offset indicates the starting index of that setting, moveNext indicates when the next setting's index is incremented'
	Encrypter.Encrypt(string source); encrypts the given string and returns the result in base64 string 
	Encrypter.Decrypt(string source); decryipts the given encrypted string and returns the resulting decrypted string. 

	ScrambleConfiguration can be I, II, III, IV, or V

# File Handling
	FileIO.Write(string path, string content, bool override); appends the content at the end of the file. if override is true the target file will be cleared and the content will be appended at the very start
	FileIO.WriteLine(string path, string content, bool override); same as above, only this always appends on a new line.
	FileIO.Read(string path); reads all text as one single string
	FileIO.TryRead(string path); reads all tet as one single string, if no file exists at the given path it returns null
	FileIO.ReadLine(string path, int line); reads the specified line if it exists in the file.
	FileIO.ReadAllLines(string path); reads all lines and returns it as a string[]

# Extention Methods
	FirstCapital(this string source); converts all letters in the string to lowercase, but makes the first letter capital
	FirstCapitalOnAllWords(this string source); converts all first letters of each word seperated with a space to a capital letter. all other letters are converted to lower case
	Foreach<T>(this IEnumerable<T> list, Action<T> action); repeats the action for each entry of the IEnumerable (list, array)
	ForeachFunc(this IEnumerable<T> list, Func<T, IEnumerable<T>>; repeats the action for each entry and returns a list with each treated object. (e.g. numbers.ForeachFunc(x => x += 1); would return a IEnumerable<T> where each number has recieved +1 number)

# Console Extras
	Input.GetKey(ConsoleKey key, bool intercept, bool wait = true); gets the given key, and waits if the Wait parameter is set to true
	ConsoleE.WriteErrorLine<T>(T Message); writes the given message in red text and a tab on a new line
	ConsoleE.WriteError<T>(T Message); wirtes the given message in red text and a tab
	ConsoleE.WriteWarningLine<T>(T Message); writes the given message in yellow text and a tab on a new line
	ConsoleE.WriteWarning<T>(T Message); writes the given message in yellow text and a tab 

# Math (also exist in extention form)
	FloorToInt(double num); floors the given double by voiding the decimals and returns the result as an int
	FloorToInt(float num); floors the given float by voiding the decimals and returns it as an int
	CeilingToInt(double num); raises the given double by voiding the decimals and adding 1, then returns the result as an int
	CeilingToInt(float num); raises the given float by voiding the decimals and adding 1, then returns the result as an int

# Vector3
	holds 3 float values to represent the 3 axis of motion in a 3D space
	Vector3.Distance(); calculate the distance between 2 vector3 points within a straight line
	Vector3.Random(); returns a random vector3
	contains definitions for math operations directly on the class itself (e.g. Vector3 + Vector3)

# Vector2
	holds 2 float values to represent the 2 axis of motion in a 2D space
	Vector2.Distance(); calculate the distance between 2 Vector2 points within a straight line
	Vector2.Random(); returns a random Vector2
	contains definitions for math operations directly on the class itself (e.g. Vector2 + Vector2)

# TypeWorker
	TypeWorker.FindType(string typeName, Assembly? assembly = null); if no assembly was given, it searches through all available assemblies and returns the found type. if none were found it returns null
	TypeWorker.FindType(string typeName, string assemblyName); searchest for the specified assembly, if one is found it searches through it for the type with the given name, if no type was found returns null, otherwise it reutnrs the found ype
	TypeWorker.CastPrimitive<T>(dynamic from, T to, Assembly? targetAssembly = null, string? targetTypeName = null) casts the given object to the given target. should assembly AND typename be given, the "T to" will be ignored and the method will use the type that is found for the casting process.
	TRypeWorker.CastPrimitive<T>(dynamic from); casts the given object to the given type. 
	
# StringWorker
	StringWorker.FirstCapital(this string source); makes the first letter of this string a capital letter, while making all other letters lowercase
	StringWorker.FirstCapitalOnAllWords(this string source); makes the first letter of every space seperated segment a capital letter, while making all other letters lowercase



# How to install
	open visual studio
	place the contents of the library zip file inside your project files (specific directory does not matter, as long as it is ultimately in the project folder)
	rightclick the project you wish to add the library to
	go to: add
	go to: add project refference
	go to: browse
	click browse in the bottom right
	find the SnowLibrary.dll within your project files
	click 'Ok' in the bottom right
	done