
namespace RestApi.BL
{

    public class CalcBL
    {
        public float Multiply(float num1, float num2)
        {
            return num1 * num2;
        }

        public float Divide(float num1, float num2)
        {
            if (num2 == 0)
            throw new ArgumentException("Cannot divide by zero.");
            return num1 / num2;
        }

        public float Add(float num1, float num2)
        {
            return num1 + num2;
        }

        public float Subtract(float num1, float num2)
        {
            return num1 - num2;
        }
    }

}
