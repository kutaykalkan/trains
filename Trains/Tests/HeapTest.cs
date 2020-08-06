using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Trains.Interfaces;
using Trains.Utilities;

namespace Trains.Tests
{
    [TestFixture]
    public class HeapTest
    {
        [Test]
        public void TestHeapBySorting() {
            var minHeap = new MinHeap<int>(new[] { 9, 8, 4, 1, 6, 2, 7, 4, 1, 2 });
            AssertHeapSort(minHeap, minHeap.OrderBy(i => i).ToArray());

            minHeap = new MinHeap<int> { 7, 5, 1, 6, 3, 2, 4, 1, 2, 1, 3, 4, 7 };
            AssertHeapSort(minHeap, minHeap.OrderBy(i => i).ToArray());
        }

        private static void AssertHeapSort(Heap<int> heap, IEnumerable<int> expected) {
            var actual = new List<int>();
            while (heap.Count > 0)
                actual.Add(heap.ExtractDominating());

            Assert.IsTrue(actual.SequenceEqual(expected));
        }

        [Test]
        public void AssertHeapSortWithComplexType() {
            MinHeap<KeyValuePair<int, int>> heap = new MinHeap<KeyValuePair<int, int>>(Comparer<KeyValuePair<int, int>>.Create((x, y) => x.Value.CompareTo(y.Value)));
            heap.Add(new KeyValuePair<int, int>(3, 6));
            heap.Add(new KeyValuePair<int, int>(2, 5));
            heap.Add(new KeyValuePair<int, int>(1, 3));
            var actual = new List<int>();
            while (heap.Count > 0)
                actual.Add(heap.ExtractDominating().Key);
            Assert.AreEqual(actual, new List<int>() {1, 2, 3});
        }
    }
}
