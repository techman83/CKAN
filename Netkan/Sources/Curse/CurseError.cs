namespace CKAN.NetKAN.Sources.Curse
{
    /// <summary>
    /// Internal class to read errors from Curse.
    /// </summary>
    internal class CurseError
    {
        // Currently only used via JsonConvert.DeserializeObject which the compiler
        // doesn't pick up on.
        public string? error;
        public string? message;
    }
}
