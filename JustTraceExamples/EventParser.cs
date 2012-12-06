namespace JustTraceExamples
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    
    public class EventParser
    {
        const string StartTag = "<EventID>";
        const string EndTag = "</EventID>";

        private static FileStream OpenFile(string filename)
        {
            return new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None, 16 * 1024 * 1024);
        }

        public Dictionary<int, int> CountEvents(string filename)
        {
            using (var reader = new StreamReader(OpenFile(filename)))
            {
                var events = new Dictionary<int, int>();

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    var line = reader.ReadLine();

                    int startIdx;

                    if ((startIdx = line.IndexOf(StartTag)) >= 0)
                    {
                        var endIndex = line.IndexOf(EndTag);

                        if (endIndex >= 0)
                        {
                            var eventId = int.Parse(line.Substring(startIdx + StartTag.Length, endIndex - startIdx - StartTag.Length));

                            int count;

                            if (!events.TryGetValue(eventId, out count))
                            {
                                events[eventId] = 1;
                            }
                            else
                            {
                                events[eventId] = count + 1;
                            }
                        }
                    }
                }

                return events;
            }
        }
    }
}
