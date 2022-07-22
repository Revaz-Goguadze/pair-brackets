# Pair Brackets

An intermediate level task for practicing algorithms, collections, tuples and enumeration types.

Estimated time to complete the task - 1h.

The task requires .NET 6 SDK installed.


## Task Description

In this task you have to implement three [extension methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods) that process a text and searches for pair of brackets.

Use [.NET collections](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections) to solve this task. Implement a method using a different collection, so each method should use a collection that is not used in other methods.


### 1. Bracket Pairs Number

Implement the [CountBracketPairs](PairBrackets/StringExtensions.cs#L10) method to return the number of bracket pairs in the `text`.

The method should support these types of brackets:
* Round brackets ()
* Square brackets []


### 2. Bracket Pair Positions

Implement the [GetBracketPairPositions](PairBrackets/StringExtensions.cs#L22) method to return the list of indexes of an open and closed positions of bracket pairs. The method returns a list of [tuples](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples).

The method should support these types of brackets:
* Round brackets ()
* Square brackets []
* Curly brackets {}


### 3. Bracket Validator

Implement the [ValidateBrackets](PairBrackets/StringExtensions.cs#L35) method to examine the `text` and returns true if the pairs and the orders of brackets are balanced. Otherwise the method should return false.

The method has the `bracketTypes` parameter that specifies what kind of brackets should be validated. The parameter is of the [enumeration type](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum).
