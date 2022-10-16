using System;
using System.Collections.Generic;
using System.Text;
using PAT.Common.Classes.Expressions.ExpressionClass;
using System.Linq; //includes ToLIST() function

//the namespace must be PAT.Lib, the class and method names can be arbitrary
namespace PAT.Lib
{
    /// <summary>
    /// The math library that can be used in your model.
    /// all methods should be declared as public static.
    /// 
    /// The parameters must be of type "int", or "int array"
    /// The number of parameters can be 0 or many
    /// 
    /// The return type can be bool, int or int[] only.
    /// 
    /// The method name will be used directly in your model.
    /// e.g. call(max, 10, 2), call(dominate, 3, 2), call(amax, [1,3,5]),
    /// 
    /// Note: method names are case sensetive
    /// </summary>

    
    public class MasterKey: ExpressionValue
    {
        public List<int> masterKeyList;

        public MasterKey()
        {
            this.masterKeyList = new List<int>();
        }

        public MasterKey(List<int> masterKeyList)
        {
            this.masterKeyList = masterKeyList;
        }

        public void AddKey(int aKey)
        {
            this.masterKeyList.Add(aKey);
        }

        public int RevealKey(int index)
        {
            return this.masterKeyList[index];
        }

        /// Return a deep clone of the hash table
        /// NOTE: this must be a deep clone, shallow clone may lead to strange behaviors.
        /// This method must be overriden
        public override ExpressionValue GetClone()
        {
            return new MasterKey(new System.Collections.Generic.List<int>(this.masterKeyList));
        }

        /// Return the compact string representation of the hash table.
        /// This method must be overriden
        /// Smart implementation of this method can reduce the state space and speedup verification 
        public override string ExpressionID {
            get
            {
                string returnString = "";
                foreach (int key in masterKeyList) {
                    returnString += key + ",";
                }
                return returnString;
            }
        }
        
        /// Return the string representation of the hash table.
        /// This method must be overriden
        public override string ToString()
        {
            return "[" + ExpressionID + "]";
        }
    }

    public class CapturedKeys: ExpressionValue
    {
        public List<int> capturedKeyList;

        public CapturedKeys()
        {
            this.capturedKeyList = new List<int>();
        }

        public CapturedKeys(List<int> capturedKeyList)
        {
            this.capturedKeyList = capturedKeyList;
        }

        public bool AddKey(int aKey, int athreshold)
        {
            if(!this.capturedKeyList.Contains(aKey))
            {
                this.capturedKeyList.Add(aKey);

                if(GetCapturedKeyListCount()>= athreshold){
                     return true;
                }
            }
            return false;
        }

        public int GetCapturedKeyListCount()
        {
           // int countKeys =0;
           // countKeys = capturedKeyList.Count;
            //return countKeys;
            return this.capturedKeyList.Count;
        }

        
        public List<int> GetList() {
            return this.capturedKeyList;
        }

        /// Return a deep clone of the hash table
        /// NOTE: this must be a deep clone, shallow clone may lead to strange behaviors.
        /// This method must be overriden
        public override ExpressionValue GetClone()
        {
            return new CapturedKeys(new System.Collections.Generic.List<int>(this.capturedKeyList));
        }

        /// Return the compact string representation of the hash table.
        /// This method must be overriden
        /// Smart implementation of this method can reduce the state space and speedup verification 
        public override string ExpressionID {
            get
            {
                string returnString = "";
                foreach (int key in capturedKeyList) {
                    returnString += key + ",";
                }
                return returnString;
            }
        }
        
        /// Return the string representation of the hash table.
        /// This method must be overriden
        public override string ToString()
        {
            return "[" + ExpressionID + "]";
        }
    }

}
