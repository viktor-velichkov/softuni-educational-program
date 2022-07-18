using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _04.Froggy
{
    public class LakeIterator : IEnumerator<int>
    {
        int index = -2;
        string direction = "forward";
        public LakeIterator(params int[] array)
        {
            this.StoneNumbers = array;
        }
        public int[] StoneNumbers { get; set; }

        public int Current => this.StoneNumbers[index];

        object IEnumerator.Current => this.StoneNumbers[index];

        public void Dispose()
        {

        }

        public bool MoveNext()
        {

            if (index != this.StoneNumbers.Length - 1 && direction == "forward")
            {
                if (index + 2 < this.StoneNumbers.Length)
                {
                    index += 2;
                    return true;
                }
                else
                {
                    index++;
                    return true;
                }
            }
            else
            {
                direction = "backward";
                if (index%2!=0)
                {
                    if (index - 2 >= 0)
                    {
                        index -= 2;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return --index >= 0;
                }
                
            }
        }

        public void Reset()
        {
            index = -2;
        }
    }
}
