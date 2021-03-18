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


    int daje = 0; 

    



    public TextMeshProUGUI msg;  //login corretto con anonimo
    public TextMeshProUGUI msg1;  // logout corretto
    public TextMeshProUGUI msg2;  //registrazione completata
    public TextMeshProUGUI msg3;  //login errato
    public TextMeshProUGUI msg4;  //Password troppo corta
    public TextMeshProUGUI msg5;  //Inserire Email
    public TextMeshProUGUI msg6; //pasw mancante
    public TextMeshProUGUI msg7;  // email non valida
    public TextMeshProUGUI msg8;  //pasw sbagliata(login)
 
    //public InputField InputField;
    

    




    public void Login()
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(emailInput.text, PasswordInput.text).ContinueWith((task =>
        {
            
            if (task.IsCanceled)
            {
                Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;


                Disattiva();
                msg3.gameObject.SetActive(true);
                
                GetErrorrMessage((AuthError)e.ErrorCode);

               // msg3.text = "LoginErrato";
               // Disattiva();
                
                //msg3.gameObject.SetActive(true);
                
                return;

            }
            if (task.IsFaulted)
            {
                Firebase.FirebaseException e = task.Exception.Flatten().InnerExceptions[0] as Firebase.FirebaseException;

                GetErrorrMessage((AuthError)e.ErrorCode);

                Disattiva();
                msg3.text = "LoginErrato";
                msg3.gameObject.SetActive(true);

                return;

            }
            if (task.IsCompleted)
            {
                
                print("utente loggato correttamente");
                daje = 1;
                LoginCOrretto();


                  //msg.text = "Login OK";
                
                msg.gameObject.SetActive(true);
               // LoginCorretto();
            }



        }));

    }
    public void LoginCOrretto()
    {
        if (daje == 1)
        {
            msg.gameObject.SetActive(true);
            StartCoroutine(Wait());
        }
    }

    public void MessaggiRegister()
     {
        if (VerificaEmail()==false)

        {


            print("email non corretta");
            //Disattiva();
            msg7.gameObject.SetActive(true);
            StartCoroutine(Wait());

        }

         if (VerificaPassword()==false){
            
                // Disattiva();
                msg4.gameObject.SetActive(true);
                StartCoroutine(Wait());
            } 
        if(VerificaEmail() == true && VerificaPassword() == true)
        {
            msg2.gameObject.SetActive(true);
            StartCoroutine(Wait());
        }
        

    }

    private Boolean VerificaEmail()
    {
        if (emailInput.text.IndexOf("@") == -1 || emailInput.text.IndexOf(".") == -1)
            return false;
        else return true;

    }

    private Boolean VerificaPassword()
    {
        if (PasswordInput.text.Length < 6)
            return false;
        else return true;
    }

    public void MessaggiLogin()
    {
        if (VerificaEmail() == false)

        {


            print("email non corretta");
            //Disattiva();
            msg7.gameObject.SetActive(true);
            StartCoroutine(Wait());

        }

        if (VerificaPassword() == false)
        {

            // Disattiva();
            msg4.gameObject.SetActive(true);
            StartCoroutine(Wait());
        }
        /*if (VerificaEmail() == true && VerificaPassword() == true)
        {
            msg.gameObject.SetActive(true);
            StartCoroutine(Wait());
        }*/
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
            //if (task.IsCompleted){
                //msg.gameObject.SetActive(true);
                //Messaggio();
            //}



        }));

    }
    public void LoginCorretto()
    {
        Disattiva();
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
        Disattiva();
        msg1.gameObject.SetActive(true);
        print("Logout effettuato ");




        

    }

    IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(3);
        Disattiva();

    }


    public void RegiterUser()
    {
        if(emailInput.text.Equals("") && PasswordInput.text.Equals(""))
        {
            Disattiva();
            msg5.gameObject.SetActive(true);
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
                 msg2.gameObject.SetActive(true);
                 //print("registrazione completata");
                 //Disattiva();
                 
             }

         }));

    }
void GetErrorrMessage(AuthError errorCode)
    {
        string msg = "";
        msg = errorCode.ToString();

       switch (errorCode)
        {
            case AuthError.MissingEmail:
               //Disattiva();
                msg5.gameObject.SetActive(true);
                break;
                
            case AuthError.WeakPassword:
               Disattiva();
               msg4.gameObject.SetActive(true);
                break;

            case AuthError.AccountExistsWithDifferentCredentials:
                break;

            case AuthError.MissingPassword:
                Disattiva();
                msg6.gameObject.SetActive(true);
                break;

            case AuthError.WrongPassword:
                Disattiva();
                
                msg8.gameObject.SetActive(true);

                break;

            case AuthError.InvalidEmail:
                Disattiva();
                msg7.gameObject.SetActive(true);
                
                break;

        }

        print(msg);
    }

    public void Disattiva()
    {
        msg.gameObject.SetActive(false);
        msg1.gameObject.SetActive(false);
        msg2.gameObject.SetActive(false);
        msg3.gameObject.SetActive(false);
        msg4.gameObject.SetActive(false);
        msg5.gameObject.SetActive(false);
        msg6.gameObject.SetActive(false);
        msg7.gameObject.SetActive(false);
        msg8.gameObject.SetActive(false);



    }
}

