

using System;

namespace _1Task.ViewModel
{
    class ApplicationViewModel
    {
        MyList<string> myList = new MyList<string>();
        public void addElement(string newItem)
        {
            myList.add(newItem);
        }

        public MyList<string> getList()
        {
            return myList;
        }

        public string getLastElementList()
        {
            return myList.getElementAt(myList.Count - 1);
        }

        public string getElementList(int index)
        {
            return myList.getElementAt(index);
        }

        public void clearList()
        {
            myList.clear();
        }

        public void deleteElement(string newItem)
        {
            myList.remove(newItem);
        }

        public int getCount()
        {
            return myList.Count;
        }


    }


}
