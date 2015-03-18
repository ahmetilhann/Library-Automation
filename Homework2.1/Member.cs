using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Homework2._1
{
    class Member
    {
        BooksOfMember mBooksHead;

        internal BooksOfMember MBooksHead
        {
            get { return mBooksHead; }
            set { mBooksHead = value; }
        }

        Member next;
        internal Member Next
        {
            get { return next; }
            set { next = value; }
        }

        int identityNo;
        public int IdentityNo
        {
            get { return identityNo; }
            set { identityNo = value; }
        }

        string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public Member(int identityNo, string firstName, string lastName, string address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.identityNo = identityNo;
            this.address = address;
            this.Next = null;
        }

    }


}