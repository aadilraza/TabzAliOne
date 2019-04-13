using System;

namespace SchoolManagementSystem.Model.Enums
{
    public enum PaymentType
    {
        Cash,
        CreditCard,
        EFT,
        Note,
        Deposit
    }
    public enum CourseOfferingState
    {
        Waiting,
        Ongoing,
        Finished,
        Canceled
    }

    [Flags]
    public enum Days
    {
        Sunday = 0x1,
        Monday = 0x2,
        Tuesday = 0x4,
        Wednesday = 0x8,
        Thursday = 0x10,
        Friday = 0x20,
        Saturday = 0x40
    }
}
