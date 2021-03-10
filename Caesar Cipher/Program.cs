using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
  
namespace Caesar_Cipher {  
    class Program {  
        public static char cipher(char ch, int key) {  
            if (!char.IsLetter(ch)) {  
  
                return ch;  
            }  
  
            char d = char.IsUpper(ch) ? 'A' : 'a';  
            return (char)((((ch + key) - d) % 26) + d);  
        } 
  
        public static string Encipher(string input, int key) {  
            string output = string.Empty;  
            foreach(char ch in input)  
            output += cipher(ch, key);  
            return output;  
        }  
  
        public static string Decipher(string input, int key) {  
            return Encipher(input, 26 - key);  
        }  

        public static void garis(){
            for(int i=0; i<40; i++){
                Console.Write("=");  
            }
        }
  
        static void Main(string[] args) {
            bool ulangi;
            do{
                garis();
                Console.Write("\n\t\tCaesar Cipher\n");
                garis();

                Console.Write("\nMasukan Text\t: ");  
                string Text = Console.ReadLine();  
                Console.Write("Masukan Key\t: ");  
                int key = Convert.ToInt32(Console.ReadLine());  

                Console.WriteLine("1. Encrypted");  
                Console.WriteLine("2. Decrypted");  
                Console.Write("Pilihan Anda\t: ");
                int pilihan = Convert.ToInt32(Console.ReadLine());  
                
                if(pilihan == 1){
                string cipherText = Encipher(Text, key);  
                Console.WriteLine("Encrypted Data\t: " + cipherText);} 
                else if(pilihan == 2){
                string t = Decipher(Text, key);   
                Console.WriteLine("Decrypted Data\t: " + t);
                } else{
                    Console.WriteLine("Pilihan Tidak Ditemukan!");  
                }
                
                Console.Write("Apakah Anda Ingin Menginputkan Lagi[Y/T]: ");  
                char ulang = Console.ReadKey().KeyChar;
                if(ulang == 'Y' || ulang == 'y'){
                    ulangi = true;
                    Console.Clear();
                } else {
                    ulangi = false;
                }
            } while(ulangi == true);
        }  
    }  
} 