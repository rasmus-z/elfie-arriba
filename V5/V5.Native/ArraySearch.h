#pragma once
using namespace System;

public ref class ArraySearch
{
public:	
	static void AndWhereGreaterThan(array<Byte>^ set, Byte value, array<UInt32>^ matchVector);

	static int Count(array<UInt32>^ matchVector);
};
