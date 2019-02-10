using System.Collections.Generic;
using Xunit;

namespace ArrayFlattener.Test
{
    public class FlattenerTest
    {
        [Theory]
        [ClassData(typeof(TestDataOfPositive))]
        public void FullPositiveTest(IEnumerable<object> arrayOfArrays, IEnumerable<object> output)
        {
            IEnumerable<object> result = Flattener.Flatten(arrayOfArrays);
            Assert.Equal(output, result);
        }

        [Theory]
        [ClassData(typeof(TestDataOfNegetive))]
        public void FullNegetiveTest(IEnumerable<object> arrayOfArrays, IEnumerable<object> output)
        {
            IEnumerable<object> result = Flattener.Flatten(arrayOfArrays);
            Assert.NotEqual(output, result);
        }
    }


    public class TestDataOfPositive : TheoryData<IEnumerable<object>, IEnumerable<object>>
    {
        //test data scenarios
        public TestDataOfPositive()
        {
            Add(new object[] { }, new object[] { });
            Add(new object[] { 1, 2, 3, 4, 5, 6 }, new object[] { 1, 2, 3, 4, 5, 6 });
            Add(new object[] { 1, 2, new object[] { 4, 5 }, 6 }, new object[] { 1, 2, 4, 5, 6 });
            Add(new object[] { new object[] { 4, new object[] { 1, 2 }, 5 }, 6 }, new object[] { 4, 1, 2, 5, 6 });
            Add(new object[] { new object[] { 4, new object[] { 1, new object[] { 2 } }, 5 }, 6 }, new object[] { 4, 1, 2, 5, 6 });

        }

    }

    public class TestDataOfNegetive : TheoryData<IEnumerable<object>, IEnumerable<object>>
    {
        //test data scenarios
        public TestDataOfNegetive()
        {
            Add(new object[] { }, new object[] { 1, 2 });
            Add(new object[] { 1, 2, 3, 4, 5, 6 }, new object[] { 1, 2, 3, 4, 5, 6, 4 });
            Add(new object[] { 1, 2, new object[] { 4, 5 }, 6 }, new object[] { 1, 2, 4, 5, 6, 5 });
            Add(new object[] { new object[] { 4, new object[] { 1, 2 }, 5 }, 6 }, new object[] { 4, 1, 2, 5, 3, 6 });
            Add(new object[] { new object[] { 4, new object[] { 1, new object[] { 2 } }, 5 }, 6 }, new object[] { 0, 4, 1, 2, 5, 6 });

        }

    }
}
