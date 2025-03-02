using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class Journal
    {
        List<JournalEntry> journal = new();
        public void WriteRecord(object source, TreeEventHandlerArgs args)
        {
            JournalEntry entry = new JournalEntry(
                args.CollectionName,
                args.ChangeType,
                args.ChangedItem
            );
            journal.Add(entry);
        }
        public void PrintJournal()
        {
            foreach (var record in journal)
            {
                Console.WriteLine(record.ToString());
            }
        }
    }
}
