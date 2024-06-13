using System.Text;

namespace Test
{
    /// <summary>
    /// Мой тестовый класс с набором св-во классических типов
    /// </summary>
    public class TestClass
    {
        /// <summary>
        /// Целочисленное св-во
        /// </summary>
        public int x1 { get; set; }

        /// <summary>
        /// Строковое св-во
        /// </summary>
        public string x2 { get; set; }

        /// <summary>
        /// Св-во с плавающей запятой
        /// </summary>
        public double x3 { get; set; }

        /// <summary>
        /// Св-во с датой
        /// </summary>
        public DateTime x4 { get; set; }

        /// <summary>
        /// Логическое св-во
        /// </summary>
        public bool x5 { get; set; }

        public override string ToString()
        {
            var str = new StringBuilder();

            str.Append("x1 = ").Append(this.x1.ToString());
            str.Append("\tx2 = ").Append(this.x2);
            str.Append("\tx3 = ").Append(this.x3.ToString());
            str.Append("\tx4 = ").Append(this.x4.ToString());
            str.Append("\tx5 = ").Append(this.x5.ToString());

            return str.ToString();
        }
    }
}
