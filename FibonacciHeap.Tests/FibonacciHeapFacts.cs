using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FibonacciHeap;

namespace FibonacciHeap.Tests
{
    public class FibonacciHeapFacts
    {
        private List<FibonacciHeapNode<int>> _addedNodes = new List<FibonacciHeapNode<int>>();
        private FibonacciHeapNode<int> _node;
        private FibonacciHeap<int> _sut;

        [Fact]
        public void It_can_be_constructed()
        {
            WhenSutIsCreated();
        }

        [Fact]
        public void It_can_store_an_element_of_data()
        {
            GivenNode();
            WhenSutIsCreated();
            _sut.Insert(_node);
        }

        [Fact]
        public void It_can_order_two_nodes_correctly()
        {
            WhenSutIsCreated();
            WhenNodeIsAdded(0,0);
            WhenNodeIsAdded(2,5);
            Assert.Equal(_addedNodes[0],_sut.Min());
        }

        private void WhenNodeIsAdded(int data, int key)
        {
            GivenNode(data,key);
            _sut.Insert(_node);
            _addedNodes.Add(_node);
        }

        private void GivenNode(int data=0, int key=0)
        {
            _node = new FibonacciHeapNode<int>(data, key);
        }

        private void WhenSutIsCreated()
        {
            _sut = new FibonacciHeap<int>();
        }
    }
}
