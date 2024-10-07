using System;
using System.Collections;
using System.Collections.Generic;

namespace TestTask.HashData
{
    class ApplicationContactsDirectory //Task Three
    {

        public void ApplicationStart()
        {
            IOManager iOManager = new IOManager();
            iOManager.ApplicationState(State.Start);
            while (true)
            {
                iOManager.InputCommand();
            }           
            
        }
    }

    public class ContactsDirectory
    {
        private Hashtable _hashtable;

        public ContactsDirectory()
        {
            _hashtable = new Hashtable();
        }

        public ulong SetHashKey(string name)
        {
            ulong sum = 0;
            foreach(char c in name)
            {
                sum += c;
            }
            string result = sum + ((int)name[name.Length - 1]).ToString();
            return ulong.Parse(result);
        }

        public bool AddToHashTable(ulong key, Data data)
        {
            if(!_hashtable.Contains(key))
            {
                _hashtable.Add(key, data);
                return true;
            }

            return false;
        }

        public bool RemoveToHashTable(ulong key)
        {
            if (_hashtable.Contains(key))
            {
                _hashtable.Remove(key);
                return true;
            }
            return false;
        }

        public void ChangeData(ulong key, Data data)
        {
            _hashtable[key] = data;
        }

        public Data GetDataToHashTable(ulong key)
        {
            return (Data)_hashtable[key];

        }
    }

    public class IOManager
    {
        private string _startTitleString = "Телефонный справочник";
        private string _inputNameString = "Введите И.О.Ф и нажмите Enter ";
        private string _inputTelString = "Введите номер телефона и нажмите Enter ";
        private string _inputCommandString = "Введите команду: \n1 - добавить данные \n2 - изменить данные \n3 - удалить данные\n4 - найти данные";
        private string _delDataString = "Данные удалены";
        private string _addDataString = "Данные добавлены";
        private string _changeDataString = "Данные изменены";
        private string _dataIsExistString = "Данные уже существуют";
        private string _notFoundDataString = "Данные не найдены";
        private string _incorrectDataString = "Неверные данные";
        private string _incorrectCommandString = "Неверная команда";

        private ContactsDirectory _contactsDirectory;

        public IOManager()
        {
            _contactsDirectory = new ContactsDirectory();
        }

        public void ApplicationState(State state)
        {
            switch (state)
            {
                case State.Start:
                    Console.WriteLine(_startTitleString);
                    break;
                case State.AddData:
                    AddData();
                    break;
                case State.ChangeData:
                    ChangrData();
                    break;
                case State.DeleteData:
                    DeleteData();
                    break;
                case State.FoundData:
                    GetFoundData();
                    break;
            }
        }

        private void AddData()
        {
            string name = InputDataName();
            ulong key = _contactsDirectory.SetHashKey(name);
            long tel = InputDataTel();
            bool isCompleate = _contactsDirectory.AddToHashTable(key, new Data(name, tel));
            if (isCompleate) Console.WriteLine(_addDataString);
            else Console.WriteLine(_dataIsExistString);
        }

        private void ChangrData()
        {
            string name = InputDataName();
            ulong key = _contactsDirectory.SetHashKey(name);
            Data data = _contactsDirectory.GetDataToHashTable(key);           
            if(data != null)
            {
                long tel = InputDataTel();
                _contactsDirectory.ChangeData(key, new Data(name, tel));
                Console.WriteLine(_changeDataString);
            }
            else
            {
                Console.WriteLine(_notFoundDataString);
            }
        }

        private void DeleteData()
        {
            ulong key = _contactsDirectory.SetHashKey(InputDataName());
            bool isCompleate = _contactsDirectory.RemoveToHashTable(key);
            if(isCompleate)Console.WriteLine(_delDataString);
            else Console.WriteLine(_notFoundDataString);
        }

        private void GetFoundData()
        {
            
            ulong key = _contactsDirectory.SetHashKey(InputDataName());
            Data data = _contactsDirectory.GetDataToHashTable(key);
            if(data != null) Console.WriteLine(data);
            else Console.WriteLine(_notFoundDataString);
        }

        private string InputDataName()
        {
            do
            {
                Console.Write(_inputNameString);
                string result = Console.ReadLine();
                if (result.Length > 0) return result;
                Console.WriteLine(_incorrectDataString);
            } while (true);
            
        }

        private long InputDataTel()
        {
            do
            {
                Console.WriteLine(_inputTelString);
                string stringData = Console.ReadLine();
                if (long.TryParse(stringData, out long numTel))
                {
                    return numTel;
                }
                Console.WriteLine(_incorrectDataString);
                
            } while (true);
        }

        public void InputCommand()
        {
            do
            {
                Console.WriteLine(_inputCommandString);
                string stringData = Console.ReadLine();
                try
                {
                    State state = (State)Enum.Parse(typeof(State), stringData);
                    if ((int)state > 0)
                    {
                        ApplicationState(state);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(_incorrectCommandString);
                    }
                }
                catch
                {
                    Console.WriteLine(_incorrectCommandString);
                }


            } while (true);
        }
    }

    public enum State
    {
        Start,
        AddData,
        ChangeData,
        DeleteData,
        FoundData,
    }

    public class Data
    {
        public string Name { get; private set; }
        public long PhoneNum { get; private set; }

        public Data(string name, long phoneNum)
        {
            Name = name;
            PhoneNum = phoneNum;
        }

        public override string ToString()
        {
            return Name + " - " + PhoneNum;
        }
    }
}
