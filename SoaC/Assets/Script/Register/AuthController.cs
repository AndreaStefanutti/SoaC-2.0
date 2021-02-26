using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using System;
using TMPro;




public class AuthController : MonoBehaviour
{
    public Text emailInput, PasswordInput;

    public TextMeshProUGUI msg;  //login corretto con anonimo
    public TextMeshProUGUI msg1;  // logout corretto
    public TextMeshProUGUI msg2;  //registrazione completata
    public TextMeshProUGUI msg3;
    public TextMeshProUGUI msg4;  //Password troppo corta
    public TextMeshProUGUI msg5;  //email non valida

    public InputField InputField;
    

    




    public void Login()
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(emailInput.text, PasswordInput.text).ContinueWith((task =>
        {
            
            if (task.IsCanceled)
            {
                Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorrMessage((AuthError)e.ErrorCode);
                msg3.text = "LoginErrato";
                return;

            }
            if (task.IsFaulted)
            {
                Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorrMessage((AuthError)e.ErrorCode);
                return;

            }
            /*if (task.IsCompleted)
            {
              
                print("utente loggato correttamente");

                msg.text = "Login OK";
            }*/



        }));

    }

    /*public void MessaggiRegister()
     {   if (InputField.text.Length < 6)
         {
             print("d");
             msg4.gameObject.SetActive(true);
             print("b");

         }
         else
         {
             msg2.gameObject.SetActive(true);
             print("Registrazione effettuata");
         }
     }
    */














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
            //if (task.IsCompleted){
                //msg.gameObject.SetActive(true);
                //Messaggio();
            //}



        }));

    }
    public void LoginCorretto()
    {
        msg.gameObject.SetActive(true);
        print("utente loggato correttamente con l'anonimo");

    }
    
    public void Logout()
    {
        if(FirebaseAuth.DefaultInstance.CurrentUser != null)
        {
            FirebaseAuth.DefaultInstance.SignOut();
        }
    }
    public void LogoutCorretto()
    {
        msg1.gameObject.SetActive(true);
        print("Logout effettuato ");
        

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
                msg5.text = "Devi scrivere la password";
                break;

            case AuthError.WrongPassword:
                msg4.text = "Troppo corta";
                break;

            case AuthError.InvalidEmail:
                
                break;

        }

        print(msg);
    }
}
