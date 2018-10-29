using System;

namespace P03_DependencyInversion
{
    public class PrimitiveCalculator
    {
        private bool isAddition;
        private bool isDivaded;
        private AdditionStrategy additionStrategy;
        private SubtractionStrategy subtractionStrategy;
        private MultiplicationStrategy multiplicationStrategy;
        private DivisionStrategy divisionStrategy;

        public PrimitiveCalculator()
        {
            this.additionStrategy = new AdditionStrategy();
            this.subtractionStrategy = new SubtractionStrategy();
            this.multiplicationStrategy = new MultiplicationStrategy();
            this.divisionStrategy = new DivisionStrategy();
            this.isAddition = true;

        }
        // public enum Operators { add, substract, multiplication ,divided };

        public void ChangeStrategy(char @operator)
        {

            //switch (@operator)
            //{
            //    case '+':
            //        this.isAddition = true;
            //        break;
            //    case '-':
            //        this.isAddition = false;
            //        break;
            //    case '/':
            //        this.isDivaded = true;
            //        break;
            //    case '*':
            //        this.isDivaded = false;
            //        break;
            //}
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            //if (this.isAddition)
            //{
            //    return additionStrategy.Calculate(firstOperand, secondOperand);
            //}
            //if (!isAddition)
            //{
            //    return subtractionStrategy.Calculate(firstOperand, secondOperand);
            //}
            //if (isDivaded)
            //{
            //    return divisionStrategy.Calculate(firstOperand, secondOperand);
            //}
            //if (!isDivaded)
            //{
            //    return multiplicationStrategy.Calculate(firstOperand, secondOperand);

            //}
            //else
            //{
            //    throw new ArgumentException("_!_");
            //}
            return 1;
        }
    }
}
