using Lab12;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class TreeEventHandlerArgs : EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public object ChangedItem { get; set; }

        public TreeEventHandlerArgs(string collectionName, string changeType, object changedItem)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ChangedItem = changedItem;
        }

        public override string ToString()
        {
            return $"Коллекция: {CollectionName}, Изменение: {ChangeType}, Предмет: {ChangedItem?.ToString()}";
        }
    }

    public delegate void TreeEventHandler(object treeName, TreeEventHandlerArgs args);
    public class TreeEvent<T>: BinaryTree<T>
    {
        public string Name { get; set; } = "";
        public event TreeEventHandler TreeCountChanged;
        public event TreeEventHandler TreeReferenceChanged;
        public TreeEvent(string name): base()
        {
            Name = name;
        }
        private IEnumerator<T> GetEnumeratorAtIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Индекс за диапазоном значений");
            }
            var enumerator = base.GetEnumerator();
            for (int i = 0; i < index; i++)
            {
                enumerator.MoveNext();
            }
            enumerator.MoveNext();
            return enumerator;
        }
        public T this[int index] {
            get
            {
                var enumerator = GetEnumeratorAtIndex(index);
                return enumerator.Current;
            }
            set
            {
                var enumerator = GetEnumeratorAtIndex(index);
                this.Change(enumerator.Current, value);
            }
        }


        private void OnCollectionCountChanged(object tree, TreeEventHandlerArgs args)
        {
            TreeCountChanged?.Invoke(this, args);
        }

        private void OnCollectionReferenceChanged(object tree, TreeEventHandlerArgs args)
        {
            TreeReferenceChanged?.Invoke(this, args);
        }

        public new void Add(T item) {
            base.Add(item);
            OnCollectionCountChanged(this, new TreeEventHandlerArgs(Name, " был добавлен элемент ", item));
        }
        public new bool Remove(T item)
        {
            bool result = base.Remove(item);
            if (result)
            {
                OnCollectionCountChanged(this, new TreeEventHandlerArgs(Name, " был удален элемент ", item));
            }
            return result;
        }
        public new bool Remove(int index)
        {
            var enumerator = GetEnumeratorAtIndex(index);
            bool result = base.Remove(enumerator.Current);
            if (result)
            {
                OnCollectionCountChanged(this, new TreeEventHandlerArgs(Name, " был удален элемент ", enumerator.Current));
            }
            return result;

        }

        public void Change(T oldItem, T newItem)
        {
            if (this.Contains(oldItem))
            {
                base.Remove(oldItem);
                base.Add(newItem);
                OnCollectionReferenceChanged(this, new TreeEventHandlerArgs(Name, " был удален элемент ", oldItem));
                OnCollectionReferenceChanged(this, new TreeEventHandlerArgs(Name, " был изменен на ", newItem));
            }
        }
    }
}
