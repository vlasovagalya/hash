using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash

{
    class Hash
    {
        class KeyValue
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }
        List<List<KeyValue>> list;

        class HashData
        {
            public readonly int KeyHash;
            public object Value { get; set; }

            public HashData(int h, object obj)
            {
                KeyHash = h;
                Value = obj;
            }
        }
        private List<HashData>[] data;
        
        public Hash(int size)
        {
            data = new List<HashData>[size];
        }
        
        public void PutPair(object key, object value)
        {
            var index = Math.Abs(key.GetHashCode()) & list.Count;
            var keyHashCode = key.GetHashCode();
            foreach (var p in list[index])
            {
                if (Equals(p.Key, key))
                {
                    p.Value = value;
                    return;
                }
            }

            list[index].Add(new KeyValue { Key = key, Value = value });
        }
        public object GetValueByKey(object key)
        {
            var BucketNo = Math.Abs(key.GetHashCode()) & list.Count;
            foreach (var p in list[BucketNo])
            {
                if (Equals(p.Key, key))
                {
                    return p.Value;
                }
            }

            return null;
        }
    }
}