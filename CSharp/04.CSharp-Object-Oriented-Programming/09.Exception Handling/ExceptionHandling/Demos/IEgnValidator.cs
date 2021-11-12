namespace Demos
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEgnValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="egn"></param>
        /// <returns></returns>
        bool Validate(string egn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="birthDate"></param>
        /// <param name="city"></param>
        /// <param name="isMale"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCityException"></exception>
        string[] Generate(DateTime birthDate, string city, bool isMale, int count = 5);
    }
}