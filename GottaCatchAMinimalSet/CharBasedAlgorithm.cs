using System;
using System.Collections.Generic;
using System.Linq;

namespace GottaCatchAMinimalSet
{
    public class CharBasedAlgorithm
    {
        private List<string> _completeList;
        private Dictionary<char, List<string>> _containingCharacters;
        private List<char> _characterOrder;
        private List<string> _minimalList;
        private List<List<string>> _minimalLists;

        public List<List<string>> Run(List<string> list)
        {
            _completeList = list;
            _containingCharacters = new Dictionary<char, List<string>>();
            InitialiseCharOrder();
            _minimalList = list;
            Process(new List<string>());
            return _minimalLists;
        }

        private void InitialiseCharOrder()
        {
            List<char> alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray().ToList();
            string joinedList = String.Join("", _completeList);
            _characterOrder = alphabet.OrderBy(c => joinedList.Count(f => f == c)).ToList();
        }

        private void Process(List<string> set)
        {
            if (IsComplete(set))
            {
                if (IsMinimal(set))
                {
                    _minimalList = set;
                    _minimalLists = new List<List<string>> { set };
                }
                else if (EqualsMinimal(set))
                {
                    _minimalLists.Add(set);
                }
            }
            else if (set.Count < _minimalList.Count)
            {
                var missingChars = MissingChars(set);
                if (missingChars.Count < (CharLength(_minimalList) - CharLength(set)) || set.Count != _minimalList.Count - 1)
                {
                    foreach (var name in ContainingCharacter(missingChars.First()))
                    {
                        var newSet = new List<string>(set);
                        newSet.Add(name);
                        Process(newSet);
                    }
                }
            }
        }

        private List<string> ContainingCharacter(char c)
        {
            if (!_containingCharacters.ContainsKey(c))
            {
                _containingCharacters[c] = _completeList.Where(name => name.Contains(c)).OrderBy(name => name.Length).ToList();
            }
            return _containingCharacters[c];
        }

        private bool IsComplete(List<string> set)
        {
            return !MissingChars(set).Any();
        }

        private bool IsMinimal(List<string> set)
        {
            return set.Count < _minimalList.Count || (set.Count == _minimalList.Count && CharLength(set) < CharLength(_minimalList));
        }

        private bool EqualsMinimal(List<string> set)
        {
            return set.Count == _minimalList.Count && CharLength(set) == CharLength(_minimalList);
        }

        private List<char> MissingChars(List<string> set)
        {
            return _characterOrder.Except(String.Join("", set).ToCharArray().ToList()).ToList();
        }

        private int CharLength(List<string> set)
        {
            return String.Join("", set).Length;
        }
    }
}
