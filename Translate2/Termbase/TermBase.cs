using System;
using System.Collections.Generic;
using System.Linq;

namespace Translate2
{
    public class Termbase
    {
        public string TermText { get; set; }
        public string Translation { get; set; }

        public Term(string termText, string translation)
        {
            TermText = termText;
            Translation = translation;
        }
    }

    public class TermLibrary
    {
        private List<Term> terms;

        public TermLibrary()
        {
            terms = new List<Term>();
        }

        public void AddTerm(string termText, string translation)
        {
            terms.Add(new Term(termText, translation));
        }

        public List<Term> SearchTerm(string keyword)
        {
            return terms.Where(term => term.TermText.Contains(keyword)).ToList();
        }

        public bool EditTerm(string termText, string newTranslation)
        {
            Term term = terms.Find(t => t.TermText == termText);
            if (term != null)
            {
                term.Translation = newTranslation;
                return true;
            }
            return false;
        }

        public bool DeleteTerm(string termText)
        {
            Term term = terms.Find(t => t.TermText == termText);
            if (term != null)
            {
                terms.Remove(term);
                return true;
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TermLibrary termLibrary = new TermLibrary();

            if ()
            {
                termLibrary.AddTerm("apple", "ƻ��");//�������
            }

            if ()
            {
                List<Term> results = termLibrary.SearchTerm("apple");
                foreach (Term term in results)
                {
                    Console.WriteLine($"{term.TermText} : {term.Translation}");
                }//��������
            }

            if ()
            {
                termLibrary.EditTerm("apple", "ƻ����ˮ����");//�༭����
            }

            if ()
            {
                termLibrary.DeleteTerm("apple");//ɾ������
            }
        }
    }
}
