using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;


public class AuthController : MonoBehaviour
{
    public Text emailInput, PasswordInput;

    public void Login()
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(emailInput.text, PasswordInput.text).ContinueWith((task =>
        {

            if (task.IsCanceled)
            {
                Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorrMessage((AuthError)e.ErrorCode);
                return;

            }
            if (task.IsFaulted)
            {
                Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorrMessage((AuthError)e.ErrorCode);
                return;

            }
            if (task.IsCompleted)
            {
                print("utente loggato correttamente");

            }
        }));

    }

    public void Login_Anonymous()
    {
        FirebaseAuth.DefaultInstance.SignInAnonymouslyAsync().ContinueWith((task =>
        {

            if (task.IsCanceled)
            {
                Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorrMessage((AuthError)e.ErrorCode);
                return;

            }
            if (task.IsFaulted)
            {
                Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorrMessage((AuthError)e.ErrorCode);
                return;

            }
            if (task.IsCompleted)
            {
                print("utente loggato correttamente");

            }

        }));

    }
    public void Logout()
    {
        if(FirebaseAuth.DefaultInstance.CurrentUser != null)
        {
            FirebaseAuth.DefaultInstance.SignOut();
        }
    }


   public void RegiterUser()
    {
        if(emailInput.text.Equals("") && PasswordInput.text.Equals(""))
        {
            print("please inserisci email e password per registrarti");
            return;
        }
        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(emailInput.text, PasswordInput.text).ContinueWith((task =>
         {
             if (task.IsCanceled)
             {
                 Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                 GetErrorrMessage((AuthError)e.ErrorCode);
                 return;
             }
             if (task.IsFaulted)
             {
                 Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                 GetErrorrMessage((AuthError)e.ErrorCode);
                 return;
             }
             if (task.IsCompleted)
             {
                 print("registrazione completata");
             }

         }));

    }
void GetErrorrMessage(AuthError errorCode)
    {
        string msg = "";
        msg = errorCode.ToString();

        switch (errorCode)
        {
            case AuthError.AccountExistsWithDifferentCredentials:
                break;

            case AuthError.MissingPassword:
                break;

            case AuthError.WrongPassword:
                break;

            case AuthError.InvalidEmail:
                break;

        }

        print(msg);
    }
}
