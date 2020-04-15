using System;


/// <summary>
/// Summary description for ICommon
/// </summary>
namespace ANWO.Presentation
{
    //Implement directly on page
    public interface IMessage
    {
        void ShowMessage(string message);
        void ClearMessage();
    }
}