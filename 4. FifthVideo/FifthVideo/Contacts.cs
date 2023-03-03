namespace FifthVideo
{
    public class Contact
    {
        public Contact(string name, string phoneNumber, string adress)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = adress;
        }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

    }
        
}