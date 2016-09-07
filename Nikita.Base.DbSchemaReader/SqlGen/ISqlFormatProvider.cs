namespace Nikita.Base.DbSchemaReader.SqlGen
{
    interface ISqlFormatProvider
    {
        string Escape(string name);
        string LineEnding();
        string RunStatements();
        int MaximumNameLength { get; }
    }
}
