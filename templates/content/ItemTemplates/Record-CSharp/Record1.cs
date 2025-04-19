namespace Company.ClassLibrary1;

#if (Type == "class")
internal sealed record class Record1
#else
internal readonly record struct Record1
#endif
{

}