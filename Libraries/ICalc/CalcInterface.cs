namespace CalcInterface
{
    /// <summary>
    /// Interface for the plugins
    /// </summary>
    public interface ICalc
    {
        public string Calculate(string a, string b, string op);
    }
}