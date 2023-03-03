namespace ContactBook_v2
{
    public class ContactsList
    {
        private Contact[] _contact;

        public ContactsList(int maxContacts)
        {
            _contact = new Contact[maxContacts];

            _contact[0] = new Contact("Иванов Дмитрий", "8 (995) 357 87 35", "Москва");
            _contact[1] = new Contact("Керимов Михаил", "8 (905) 307 17 36", "Санкт-Петербург");
            _contact[2] = new Contact("Семенов Константин", "8 (990) 151 80 15", "Ростов-на-Дону");
            _contact[3] = new Contact("Ляхов Денис", "8 (900) 451 60 18", "Екатеринбург");
        }

        public Contact[] GetContacts()
        {
            int contactsCount = GetContactsCount();
            Contact[] result = new Contact[contactsCount];

            for (int i = 0; i < contactsCount; i++)
            {
                result[i] = _contact[i];
            }

            return result;
        }

        public int GetContactsCount()
        {
            int count = 0;

            for (int i = 0; i < _contact.Length; i++)
            {
                if (_contact[i] != null)
                    count++;
            }

            return count;
        }

        public void AddContact(Contact contact)
        {
            int newContactIndex = GetContactsCount();
            _contact[newContactIndex] = contact;
        }

        public void DeleteContact(int contactIndex)
        {
            _contact[contactIndex] = null;

            for (int i = 0; i < _contact.Length; i++)
            {
                if (_contact[i] == null && _contact[i + 1] != null)
                    (_contact[i], _contact[i + 1]) = (_contact[i + 1], _contact[i]);
                else if (_contact[i] == null && _contact[i + 1] == null)
                    break;
            }
        }
    }
}