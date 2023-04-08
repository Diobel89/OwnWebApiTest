using Microsoft.AspNetCore.Mvc;
using OwnWebApiTest.Algorythms;
using OwnWebApiTest.Algorythms.Interface;
using OwnWebApiTest.Models;
using System;

namespace OwnWebApiTest.Controllers
{
    public class UserInputsController : Controller
    {
        private readonly IBubbleSort? _bubbleSort = new BubbleSort(); // coś nie tak z tym ;/
        private readonly IInsertionSort? _insertionSort = new InsertionSort();
        private readonly IMergeSort? _mergeSort = new MergeSort();
        private readonly ITreeSort? _treeSort = new TreeSort();
        private readonly ISelectionSort? _selectionSort = new SelectionSort();
        private readonly IQuickSort? _quickSort = new QuickSort();
        private static int[] uns;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserInput userInput)
        {
            Console.WriteLine("UserInputController został uruchomiony POST! Wartość podana: " + userInput.HowManyInts);
            //userInput.ArrayInts = GenerateRandomNumber(userInput.HowManyInts);
            if (!ModelState.IsValid)
            {
                return View();
            }else
            {
                 return Random(userInput);
            }
        }
        [HttpPost]
        public IActionResult Random(UserInput userInput)
        {
            Unsorted array = GenerateRandomNumber(userInput.HowManyInts);
            uns = array.IntArray;
            for (int i = 0; i < array.IntArray.Length; i++)
            {
                Console.WriteLine("Wyniki: " + array.IntArray[i]);
            }
            Console.WriteLine("RANDOM!");
            if (!ModelState.IsValid)
            {
                return View();
            }else
            {
                return View(array);
            }
        }
        public IActionResult SortMe(Unsorted unsorted)
        {
            Console.WriteLine("SortMe!! selected: " + unsorted.SortChoice);
            for (int i = 0; i < uns.Length; i++)
            {
                Console.WriteLine("Wyniki: " + uns[i]);
            }
            DataSetResponse sort = SortByChoosenAlgorithm(unsorted.SortChoice);
            return View(sort);
        }
        private static Unsorted GenerateRandomNumber(int size)
        {
            var array = new int[size];
            var rand = new Random();
            var maxNum = 10000;

            for (int i = 0; i < size; i++)
                array[i] = rand.Next(maxNum + 1);
            Unsorted unsorted = new Unsorted();
            unsorted.IntArray = array;
            return unsorted;
        }
        private DataSetResponse SortByChoosenAlgorithm(int? choice)
        {
            DataSetResponse sort = new DataSetResponse();
            switch (choice)
            {
                case 0:
                    {
                        sort = new DataSetResponse() { Name = "0", Time = 0 };
                        break;
                    }
                case 1:
                    {
                        sort = _bubbleSort.Sort(uns);
                        break;
                    }
                case 2:
                    {
                        sort = _insertionSort.Sort(uns);
                        break;
                    }
                case 3:
                    {
                        sort = _mergeSort.Sort(uns, 0, uns.Length - 1);
                        break;
                    }
                case 4:
                    {
                        sort = _quickSort.Sort(uns, 0, uns.Length - 1);
                        break;
                    }
                case 5:
                    {
                        sort = _selectionSort.Sort(uns);
                        break;
                    }
                case 6:
                    {
                        sort = _treeSort.Sort(uns);
                        break;
                    }
                case 7:
                    {
                        sort = new DataSetResponse() {Name = "Not Implemented", Time = 0};
                        break;
                    }
            }
            return sort;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
