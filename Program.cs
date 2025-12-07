// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information

using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

// GAME DATA STRUCTURE
public abstract class Info
{
    public abstract string GetValidStringInput(string answer);
    public abstract byte GetValidByteInput(string answer, byte minValue, byte maxValue);
    public abstract bool GetValidGenderInput(string answer);
}
public interface InfoGame
{
    void StoryMode();
    void ShowCredits();
    bool ExitGame();
}
struct Datatypes
{
    private string answer;
    private string input;
    private byte result;
    private string another;
    public void setanswer(string answer)
    {
        this.answer = answer;
    }
    public void setinput(string input)
    {
        this.input = input;
    }
    public void setresult(byte result)
    {
        this.result = result;
    }
    public void setAnother(string another)
    {
        this.another = another;
    }

    public string getanswer()
    {
        return this.answer;
    }
    public string getinput()
    {
        return this.input;
    }
    public byte getresult()
    {
        return this.result;
    }
    public string getAnother()
    {
        return this.another;
    }


}
class SavedGame : Info, InfoGame
{
    public void ClearLine()
    {
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, Console.CursorTop);
    }
    // BLINKING TEXT
    public SavedGame()
    {
        ConsoleKeyInfo consoleKeyInfo;



        string welcome = "Welcome to the World of Ultimate Magical Rumble +_+";
        string Body = "\nAng larong ito ay Ginawa para sa mga taong gusto lamang maglibang" +
                      " at maglipas oras , ito ay nakakatulong umalis ang boring ng bawat isa.";

        for (int i = 0; i < welcome.Length; i++)
        {
            char c = welcome[i];
            Console.Write(c);
            Thread.Sleep(10);
        }
        Console.WriteLine();
        for (int i = 0; i < Body.Length; i++)
        {
            char c = Body[i];
            Console.Write(c);
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("====== !! Warning for the Game !! =======");
        Console.WriteLine();
        Thread.Sleep(50);
        Console.WriteLine("Ang Game ay Sumusunod sa Alintuntunin na Merong content na Magbago sa Ugali ng mga Tao");
        Thread.Sleep(50);
        Console.WriteLine("Ang Laro Ay May Graphical na Larawan na pinagbabawal sa mga may sakit or bata");
        Thread.Sleep(50);
        Console.WriteLine("Ang Pagbabantay sa mga bata ay mahalaga kaya sa na mga magulang bantayin po natin ang ating mga anak");
        Console.WriteLine("Dahil Kahit anong Laro ang gamitin ng ating mga anak ang mahalaga kaligtasan nila");
        Thread.Sleep(50);

        Console.WriteLine();

        Console.WriteLine("Press ESC To Enter in game............");
        Console.WriteLine();

        do
        {

            consoleKeyInfo = Console.ReadKey();
            Console.WriteLine();
            Console.Beep();
            if (consoleKeyInfo.Key != ConsoleKey.Escape)
            {
                ClearLine();
                Console.WriteLine("Error: Wrong Key Please Input Esp...");
                Thread.Sleep(2000);
                ClearLine();
            }

        } while (consoleKeyInfo.Key != ConsoleKey.Escape);




    }
    // BLINK TEXT ANIMATION FOR EXIT
    public void BlinkText(string text, int times = 5, int speed = 200)
    {
        for (int i = 0; i < times; i++)
        {
            Console.Write(text);
            Thread.Sleep(speed);
            Console.Write("\r" + new string(' ', text.Length) + "\r");
            Thread.Sleep(speed);
        }
        Console.Write(text);
    }

    //LOADING ANIMATION
    public void ShowLoading(string message = "Loading", int duration = 3000)
    {
        Console.Write($"\n{message}");
        string[] spinner = { "|", "/", "-", "\\" };
        int counter = 0;
        DateTime start = DateTime.Now;

        while ((DateTime.Now - start).TotalMilliseconds < duration)
        {
            Console.Write(spinner[counter % spinner.Length]);
            Thread.Sleep(100);
            Console.Write("\b \b");
            counter++;
        }
        Console.WriteLine($" ,{message} complete!");
    }

    //SHOW STORY MODE 
    public void StoryMode()
    {

        try
        {
            ConsoleKeyInfo consoleKeyInfo;


            Console.Clear();
            Console.WriteLine("=== STORY MODE ===");
            ShowLoading("Loading Story", 2000);

            Console.WriteLine(); // Add spacing

            string storyText = "Ang larong ito Tumutukoy sa fantacy game na merong magic ang mga Character.Sa mundong puno ng panganib at hiwaga, bawat laban ay isang pagsubok ng tapang at talino." +
            "Dito, hindi sapat ang lakas—kailangan ng diskarte, bilis, at kapangyarihang kaya mong buohin mula sa iyong imahinasyon." +
            "Habang unti-unting nabubuo ang iyong karakter, lumalakas din ang iyong pagkakataon na maging alamat sa larangan ng Ultimate Magical Ramble." +
            "Makakaharap mo ang mga ibat' ibang mandirigmang may kakaibang kakayahan, bawat isa ay gutom sa tagumpay." +
            "Ito ay merong Paglalaban - laban ang mga player na kung sino ang matira matibay sa isang Battlefield." +
            "Ang Game kung Saan pwede magcustomize ng mga Skill ng Character at Kasuotan nito, ikaw mismo ang gagawa ng sariling mong" +
            "Character na Gagamiting para talunin ang mga ibang player." +
            "Sa dulo, iisa lang ang tanong…" +
            "May sapat ka bang tapang para maging pinakamalakas sa mundo ng Ultimate Magical Ramble at Talunin ang mga ibang Player na Malalakas?" +
            "Ito ang iyong kwento. Ito ang iyong laban. Handa ka na ba?";

            int textLength = storyText.Length;

            for (int i = 0; i < textLength; i++)
            {
                char currentChar = storyText[i];
                Console.Write(currentChar);
                Thread.Sleep(10); // Reduced to 50ms for better readability
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press Enter key to return to main menu...");
            Console.WriteLine();

            do
            {
                consoleKeyInfo = Console.ReadKey();

                Console.Beep();
                Console.WriteLine();
                if (consoleKeyInfo.Key != ConsoleKey.Enter)
                {
                    ClearLine();
                    Console.WriteLine("Error: Wrong Key Please Input Enter...");
                    Thread.Sleep(2000);
                    ClearLine();
                }

            } while (consoleKeyInfo.Key != ConsoleKey.Enter);
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"\nFormat Error in Story Mode: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nUnexpected Error in Story Mode: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("\nStory Mode session completed.");
        }
    }

    //SHOW CREDITS 
    public void ShowCredits()
    {
        try
        {
            ConsoleKeyInfo consoleKeyInfo;

            Console.Clear();
            Console.WriteLine("=== CREDITS ===");
            ShowLoading("Loading Credits", 1500);

            Console.WriteLine("\nCREDITS");
            Console.WriteLine("Crisostomo, Lance-Programmer/Documentation");
            Console.WriteLine("Gadon, Renwill-Programmer/Documentation");
            Console.WriteLine("Afan, Lorenz Christopher-Proctor");


            Console.WriteLine("\n\nPress Enter key to return to main menu...");

            do
            {
                consoleKeyInfo = Console.ReadKey();

                Console.Beep();
                Console.WriteLine();
                if (consoleKeyInfo.Key != ConsoleKey.Enter)
                {
                    ClearLine();
                    Console.WriteLine("Error: Wrong Key Please Input Enter...");
                    Thread.Sleep(2000);
                    ClearLine();
                }
            } while (consoleKeyInfo.Key != ConsoleKey.Enter);
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"\nFormat Error in Credits: {ex.Message}");
            Thread.Sleep(2000);
            Console.Clear();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nUnexpected Error in Credits: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("\nCredits display completed.");
        }
    }

    // EXIT GAME 
    public bool ExitGame()
    {
        Datatypes data = new Datatypes();
        try
        {
            Console.Clear();
            Console.WriteLine("=== EXIT GAME ===");
            Console.WriteLine();
            while (true)
            {
                Console.Write("Do you want to leave the game? (Y/N): ");
                data.setanswer(Console.ReadLine()!.Trim().ToUpper());

                if (data.getanswer() == "Y")
                {
                    Console.WriteLine("\nExiting game...");

                    ShowLoading("Closing game", 2000);

                    BlinkText("Thank you for playing Ultimate Magical Rumble!");
                    Console.WriteLine("\nGame closed successfully.");

                    return false; // Exit the game
                }
                else if (data.getanswer() == "N")
                {
                    Console.WriteLine("\nReturning to main menu...");
                    Thread.Sleep(1000);
                    return true; // Go back to menu
                }
                else
                {
                    ClearLine();
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                    Thread.Sleep(2000);
                    ClearLine();
                }
            }
        }
        catch (FormatException ex)
        {
            ClearLine();
            Console.WriteLine($"\nFormat Error in Exit Game: {ex.Message}");
            ClearLine();
            return true; // Return to menu on error
        }
        catch (Exception ex)
        {
            ClearLine();
            Console.WriteLine($"\nUnexpected Error in Exit Game: {ex.Message}");
            ClearLine();
            return true; // Return to menu on error
        }
        finally
        {
            Console.WriteLine("Exit Game process completed.");
        }
    }


    // INPUT VALIDATION METHODS
    protected string input = string.Empty;
    protected int Id;
    Random random = new Random();

    public override string GetValidStringInput(string answer)
    {
        Datatypes data = new Datatypes();
        while (true)
        {
            try
            {
                Console.Write(answer);
                data.setinput(Console.ReadLine()!.Trim());
                Console.Beep();
                if (!string.IsNullOrEmpty(data.getinput()))
                {
                    string input = data.getinput();

                    // ADDED VALIDATION: Check name length (3-15 characters)
                    if (input.Length < 3)
                    {
                        ClearLine();
                        Console.WriteLine("Name must be at least 3 characters long.");
                        Thread.Sleep(2000);
                        ClearLine();
                        continue;
                    }

                    if (input.Length > 15)
                    {
                        ClearLine();
                        Console.WriteLine("Name must not exceed 15 characters.");
                        Thread.Sleep(2000);
                        ClearLine();
                        continue;
                    }

                    // ADDED VALIDATION: Check for special symbols
                    if (!Regex.IsMatch(input, @"^[a-zA-Z0-9\s]+$"))
                    {
                        ClearLine();
                        Console.WriteLine("Name cannot contain special symbols. Only letters, numbers, and spaces are allowed.");
                        Thread.Sleep(2000);
                        ClearLine();
                        continue;
                    }

                    // ADDED VALIDATION: Check for leading/trailing spaces
                    if (input.StartsWith(" ") || input.EndsWith(" "))
                    {
                        ClearLine();
                        Console.WriteLine("Name cannot start or end with spaces.");
                        Thread.Sleep(2000);
                        ClearLine();
                        continue;
                    }

                    // ADDED VALIDATION: Check for multiple consecutive spaces
                    if (input.Contains("  "))
                    {
                        ClearLine();
                        Console.WriteLine("Name cannot contain multiple consecutive spaces.");
                        Thread.Sleep(2000);
                        ClearLine();
                        continue;
                    }

                    this.input = data.getinput();
                    this.Id = random.Next(1, 9999);
                    return this.input;
                }
                ClearLine();
                Console.WriteLine("Invalid input. Please enter a valid value.");
                Thread.Sleep(2000);
                ClearLine();
            }
            catch (FormatException ex)
            {
                ClearLine();
                Console.WriteLine($"Input format error: {ex.Message}. Please try again.");
                Thread.Sleep(2000);
                ClearLine();
            }
            catch (Exception ex)
            {
                ClearLine();
                Console.WriteLine($"Input error: {ex.Message}. Please try again.");
                Thread.Sleep(2000);
                ClearLine();
            }
        }
    }

    // INPUT BYTE VALIDATION
    public override byte GetValidByteInput(string answer, byte minValue, byte maxValue)
    {
        Datatypes data = new Datatypes();
        while (true)
        {
            try
            {
                Console.Write(answer);
                string input = Console.ReadLine()!;
                Console.Beep();

                if (byte.TryParse(input, out byte result) && result >= minValue && result <= maxValue)
                {
                    data.setresult(result);
                    return data.getresult();
                }

                // Clear the previous line and show error
                ClearLine();
                Console.WriteLine($"Invalid input. Please enter a number between {minValue} and {maxValue}.");
                Thread.Sleep(1000);
                ClearLine();

            }
            catch (FormatException ex)
            {
                ClearLine();
                Console.WriteLine($"Number format error: {ex.Message}. Please enter a valid number.");
                Thread.Sleep(2000);
                ClearLine();
            }
            catch (Exception ex)
            {
                ClearLine();
                Console.WriteLine($"Input error: {ex.Message}. Please try again.");
                Thread.Sleep(2000);
                ClearLine();
            }
        }
    }

    // INPUT BOOLEAN GENDER VALIDATION
    public override bool GetValidGenderInput(string answer)
    {
        Datatypes data = new Datatypes();
        while (true)
        {
            try
            {
                Console.Write(answer);
                data.setinput(Console.ReadLine()!.Trim().ToUpper());
                Console.Beep();
                if (data.getinput() == "M" || data.getinput() == "F")
                {
                    return data.getinput() == "F";
                }

                // Clear the previous line and show error
                ClearLine();
                Console.WriteLine("Invalid input. Please enter M or F.");
                Thread.Sleep(2000);
                ClearLine();
            }
            catch (FormatException ex)
            {
                ClearLine();
                Console.WriteLine($"Gender input error: {ex.Message}. Please enter M or F.");
                Thread.Sleep(2000);
                ClearLine();
            }
            catch (Exception ex)
            {
                ClearLine();
                Console.WriteLine($"Input error: {ex.Message}. Please try again.");
                Thread.Sleep(2000);
                ClearLine();
            }
        }
    }
    private bool extra;
    public string ExtraHit()
    {
        Datatypes data = new Datatypes();

        string[] choice = { "Extra Critical Hit 5%", "Extra Heal 10%", "Extra Exp 25%", "Extra Double Damage 10%" };

        string extrachoice = string.Empty;
        string extrachoice1 = string.Empty;

        while (true)
        {
            Random random = new Random();

            int extra = random.Next(choice.Length);
            int extra1 = random.Next(choice.Length);

            string extra_choice = choice[extra];
            string extra_choice1 = choice[extra1];

            if (extra_choice == extra_choice1)
            {
                continue;
            }
            else
            {
                extrachoice = extra_choice;
                extrachoice1 = extra_choice1;
                break;
            }

        }

        Console.WriteLine();
        Console.WriteLine("Do you Want Another Extra Point if(yes) = " + extrachoice + " if(no) = " + extrachoice1);
        Console.WriteLine();
        while (true)
        {
            try
            {
                Console.Write("[Answer:] ");
                data.setAnother(Console.ReadLine()!.Trim().ToLower());
                Console.Beep();

                if (data.getAnother() == "yes")
                {
                    this.extra = true;
                    return extrachoice;
                }
                else if (data.getAnother() == "no")
                {
                    this.extra = false;
                    return extrachoice1;
                }

                // Clear the previous line and show error
                ClearLine();
                Console.WriteLine("Invalid Input: Please Input Yes or No.");
                Thread.Sleep(2000);
                ClearLine();

            }
            catch (FormatException e)
            {
                ClearLine();
                Console.WriteLine($"Error: {e.Message}. Please Input Yes or No");
                Thread.Sleep(2000);
                ClearLine();
            }
            catch (Exception e)
            {
                ClearLine();
                Console.WriteLine($"Error: {e.Message}. Please Try Again.");
                Thread.Sleep(2000);
                ClearLine();
            }
        }
    }
    public bool getExtraHit()
    {
        if (extra)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
class Name : SavedGame
{
    public void CharacterIdentity(string answer)
    {
        Console.Write($"{answer}{input} ");
    }


    public void CharacterIdentity()
    {
        Console.WriteLine($"(ID:{Id})");
    }
    public int getID()
    {
        return Id;
    }

}

public class GameMenu
{
    public static void Main(string[] args)
    {
        Name game = new Name();
        SavingCharacterDataBase dataBase = new SavingCharacterDataBase();

        string[] menu = {"User Name:","User ID:","Gender Type:","Character Type:","Body Type:","Color Skin:","Eye Color:","Hair Color:","Hair Style:",
                         "Face Style:","Eye Style:","T-shirt Style:","Pants Style:", "Weapon:","Pets:","Pet Skills:","Character Power:",
                         "Potion:","Many Potion:","Item:","Ultimate:","Combo Character + Pet:","Extra point:"};

        bool main_menu = true;

        while (main_menu)

        {
            try
            {
                //Game Menu Code
                Console.Clear();
                string[] menuChoices = { "NEW GAME", "LOAD GAME", "STORY MODE", "CREDITS", "EXIT" };

                byte i = 1;

                Console.WriteLine("[ Ultimate Magical Rumble ]");
                Console.WriteLine();

                foreach (var choice in menuChoices)
                {
                    Console.WriteLine($"[{i}]{choice}");
                    i++;
                }
                byte pick = game.GetValidByteInput("[Answer]", 1, Convert.ToByte(menuChoices.Length));

                Console.Clear();
                Console.Beep();

                // Menu option 1: NEW GAME
                if (pick == 1)
                {
                    List<string> characterlist = new List<string>();

                    try
                    {
                        // Ask for character name with validation
                        Console.WriteLine("=== NEW GAME ===");
                        string characterName = game.GetValidStringInput("Enter your character's name: ");
                        characterlist.Add(characterName);
                        characterlist.Add(Convert.ToString(game.getID()));

                        // Show loading when starting new game
                        game.ShowLoading("Initializing new game", 2000);


                        //Gender Type Code parts with validation
                        Console.WriteLine("\nGender Type:");
                        Console.WriteLine("[M]Male\n[F]Female");
                        bool gender = game.GetValidGenderInput("[Answer:] ");
                        Console.Clear();

                        switch (gender)
                        {
                            case true:
                                characterlist.Add("Female");
                                break;
                            case false:
                                characterlist.Add("Male");
                                break;
                        }

                        //Character Type Code parts with validation
                        game.ShowLoading("Analyzing Choices Character", 1000);

                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();
                        string[] characterType = { "Human", "Animal", "Monster", "Fairy", "Alien", "Elf", "Back" };

                        byte a = 1;

                        Console.WriteLine("\nCharacter Type:");
                        foreach (var choice1 in characterType)
                        {
                            Console.WriteLine($"[{a}]{choice1}");
                            Thread.Sleep(50);
                            a++;
                        }
                        byte pickCType = game.GetValidByteInput("[Answer:] ", 1, Convert.ToByte(characterType.Length));
                        Console.Beep();
                        Console.Clear();

                        string character_type = Convert.ToString(characterType.GetValue(pickCType - 1)) ?? "";
                        characterlist.Add(character_type);


                        // Body Type Code parts with validation
                        game.ShowLoading("Analyzing Next...", 1000);
                        Console.Clear();
                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();
                        string[] characterbodytype = { "Skinny", "Chubby", "Chunky", "Fat", "Muscular" };

                        byte b = 1;

                        Console.WriteLine("\nBody Type:");
                        foreach (var choice2 in characterbodytype)
                        {
                            Console.WriteLine($"[{b}]{choice2}");
                            Thread.Sleep(50);
                            b++;
                        }
                        byte pickBodyType = game.GetValidByteInput("[Answer:] ", 1, (byte)characterbodytype.Length);
                        Console.Beep();
                        Console.Clear();

                        string character_BodyType = Convert.ToString(characterbodytype.GetValue(pickBodyType - 1)) ?? "";
                        characterlist.Add(character_BodyType);

                        //Color Skin Code parts with validation
                        game.ShowLoading("Analyzing Next...", 1000);
                        Console.Clear();
                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();
                        string[] skincolor = { "Dark Brown", "Light Brown", "Black", "Light", "White" };

                        byte c = 1;

                        Console.WriteLine("\nColor Skin:");
                        foreach (var choice3 in skincolor)
                        {
                            Console.WriteLine($"[{c}]{choice3}");
                            Thread.Sleep(50);
                            c++;
                        }
                        byte pickSkinColor = game.GetValidByteInput("[Answer:] ", 1, (byte)skincolor.Length);
                        Console.Beep();
                        Console.Clear();

                        string character_SkinColor = Convert.ToString(skincolor.GetValue(pickSkinColor - 1)) ?? "";
                        characterlist.Add(character_SkinColor);

                        //Eye Color Code parts with validation
                        game.ShowLoading("Analyzing Next...", 1000);
                        Console.Clear();
                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();
                        string[] eyeColor = { "Brown", "Light Brown", "Blue", "Light Blue", "Red", "Light Red", "Green", "Light Green", "Dark Red", "Pink", "Grey" };

                        byte d = 1;

                        Console.WriteLine("\nEye Color:");
                        foreach (var choice4 in eyeColor)
                        {
                            Console.WriteLine($"[{d}]{choice4}");
                            Thread.Sleep(50);
                            d++;
                        }
                        byte pickEyeColor = game.GetValidByteInput("[Answer:] ", 1, (byte)eyeColor.Length);
                        Console.Beep();
                        Console.Clear();

                        string character_EyeColor = Convert.ToString(eyeColor.GetValue(pickEyeColor - 1)) ?? "";
                        characterlist.Add(character_EyeColor);

                        //Hair Color Code parts with validation
                        game.ShowLoading("Analyzing Next...", 1000);
                        Console.Clear();
                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();
                        string[] hairColor = { "Brown", "Light Brown", "Blue", "Light Blue", "Red", "Light Red", "Green", "Light Green", "Black Red", "Pink", "Grey", "Dark red", "Blonde" };

                        byte e = 1;

                        Console.WriteLine("\nHair Color:");
                        foreach (var choice5 in hairColor)
                        {
                            Console.WriteLine($"[{e}]{choice5}");
                            Thread.Sleep(50);
                            e++;
                        }
                        byte pickHairColor = game.GetValidByteInput("[Answer:] ", 1, (byte)hairColor.Length);
                        Console.Beep();
                        Console.Clear();

                        string character_HairColor = Convert.ToString(hairColor.GetValue(pickHairColor - 1)) ?? "";
                        characterlist.Add(character_HairColor);

                        //Hair Style Code Parts with validation
                        if (gender.Equals(true))
                        {
                            // Hair Style Girl
                            game.ShowLoading("Analyzing Next...", 1000);
                            Console.Clear();
                            game.CharacterIdentity("\nYour character's name: ");
                            game.CharacterIdentity();
                            string[] hairStyle = { "Ponytail", "Braid", "Bun", "Low Bun", "Top Knot", "Step Cut" };

                            byte f = 1;

                            Console.WriteLine("\nHair Style:");
                            foreach (var choice6 in hairStyle)
                            {
                                Console.WriteLine($"[{f}]{choice6}");
                                Thread.Sleep(50);
                                f++;
                            }
                            byte pickHairStyle = game.GetValidByteInput("[Answer:] ", 1, (byte)hairStyle.Length);
                            Console.Beep();
                            Console.Clear();

                            string character_HairStyle = Convert.ToString(hairStyle.GetValue(pickHairStyle - 1)) ?? "";
                            characterlist.Add(character_HairStyle);
                        }
                        else
                        {
                            //Hair Style Boy
                            game.ShowLoading("Analyzing Next...", 1000);
                            Console.Clear();
                            game.CharacterIdentity("\nYour character's name: ");
                            game.CharacterIdentity();
                            string[] hairStyle = { "Fade", "Bowl Cut", "Long Hair", "Flat Top", "Afro", "Taper" };

                            byte f = 1;

                            Console.WriteLine("\nHair Style:");
                            foreach (var choice6 in hairStyle)
                            {
                                Console.WriteLine($"[{f}]{choice6}");
                                Thread.Sleep(50);
                                f++;
                            }
                            byte pickHairStyle = game.GetValidByteInput("[Answer:] ", 1, (byte)hairStyle.Length);
                            Console.Beep();
                            Console.Clear();

                            string character_HairStyle = Convert.ToString(hairStyle.GetValue(pickHairStyle - 1)) ?? "";
                            characterlist.Add(character_HairStyle);
                        }

                        // Face Style Code Parts with validation
                        game.ShowLoading("Analyzing Next...", 1000);
                        Console.Clear();
                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();
                        string[] faceStyle = { "Diamond", "Round", "Rectangle", "Square", "Oblong", "Heart", "Oval" };

                        byte g = 1;

                        Console.WriteLine("\nFace Style:");
                        foreach (var choice7 in faceStyle)
                        {
                            Console.WriteLine($"[{g}]{choice7}");
                            Thread.Sleep(50);
                            g++;
                        }

                        byte pickFaceStyle = game.GetValidByteInput("[Answer:] ", 1, (byte)faceStyle.Length);
                        Console.Beep();
                        Console.Clear();

                        string character_FaceStyle = Convert.ToString(faceStyle.GetValue(pickFaceStyle - 1)) ?? "";
                        characterlist.Add(character_FaceStyle);

                        //Eye Sytle Code parts with validation
                        game.ShowLoading("Analyzing Next...", 1000);
                        Console.Clear();
                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();
                        string[] eyeStyle = { "Almond", "Round", "Monold", "Protuding", "Close-Set", "Wide-Set", "Deep-Set", "Hooded" };

                        byte h = 1;

                        Console.WriteLine("\nEye Style:");
                        foreach (var choice8 in eyeStyle)
                        {
                            Console.WriteLine($"[{h}]{choice8}");
                            Thread.Sleep(50);
                            h++;
                        }

                        byte pickEyeStyle = game.GetValidByteInput("[Answer:] ", 1, (byte)eyeStyle.Length);
                        Console.Beep();
                        Console.Clear();

                        string character_EyeStyle = Convert.ToString(eyeStyle.GetValue(pickEyeStyle - 1)) ?? "";
                        characterlist.Add(character_EyeStyle);

                        //T-shirt Style Code parts with validation
                        game.ShowLoading("Analyzing Next...", 1000);
                        Console.Clear();
                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();
                        string[] tShirt = { "Boxing Shirt", "underwear Shirt", "Ninjutsu style Shirt", "Karate Shirt", "Kick boxing", "Muay thai Shirt", "Buddha Shirt", "Saitama shirt", "Naruto shirt" };

                        byte j = 1;

                        Console.WriteLine("\nT-shirt Style:");
                        foreach (var choice9 in tShirt)
                        {
                            Console.WriteLine($"[{j}]{choice9}");
                            Thread.Sleep(50);
                            j++;
                        }
                        byte pickTshirtStyle = game.GetValidByteInput("[Answer:] ", 1, (byte)tShirt.Length);
                        Console.Beep();
                        Console.Clear();

                        string character_TshirtStyle = Convert.ToString(tShirt.GetValue(pickTshirtStyle - 1)) ?? "";
                        characterlist.Add(character_TshirtStyle);

                        //Pants Style with validation
                        game.ShowLoading("Analyzing Next...", 1000);
                        Console.Clear();
                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();
                        string[] pants = { "Boxing short", "Underwear pants", "Ninjutsu style pants", "karate pant", "Kick boxing", "Muay thai pant", "Buddha style pants" };

                        byte k = 1;

                        Console.WriteLine("\nPants Style:");
                        foreach (var choice10 in pants)
                        {
                            Console.WriteLine($"[{k}]{choice10}");
                            Thread.Sleep(50);
                            k++;
                        }
                        byte pickPantsStyle = game.GetValidByteInput("[Answer:] ", 1, (byte)pants.Length);
                        Console.Beep();
                        Console.Clear();

                        string character_PantsStyle = Convert.ToString(pants.GetValue(pickPantsStyle - 1)) ?? "";
                        characterlist.Add(character_PantsStyle);

                        //Weapon Code Parts with validation
                        game.ShowLoading("Analyzing Next...", 1000);
                        Console.Clear();
                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();
                        string[] weapon = { "Sword", "Gun", "Wand", "Bow", "Magical Book", "Spear" };

                        byte l = 1;

                        Console.WriteLine("\nWeapon:");
                        foreach (var choice11 in weapon)
                        {
                            Console.WriteLine($"[{l}]{choice11}");
                            Thread.Sleep(50);
                            l++;
                        }
                        byte pickWeapon = game.GetValidByteInput("[Answer:] ", 1, (byte)weapon.Length);
                        Console.Beep();
                        Console.Clear();

                        string character_Weapon = Convert.ToString(weapon.GetValue(pickWeapon - 1)) ?? "";
                        characterlist.Add(character_Weapon);

                        //Pets Code Parts with validation
                        game.ShowLoading("Analyzing Next...", 1000);
                        Console.Clear();
                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();
                        string[] pets = { "Thunder Dog", "Fairy", "elf", "Lion king", "Monster", "Rabbit", "Dwarf", "Wolf king", "Goblin", "Witch", "Dragon", "Dinosaur", "Little Demon pet" };

                        byte m = 1;

                        Console.WriteLine("\nPets:");
                        foreach (var choice12 in pets)
                        {
                            Console.WriteLine($"[{m}]{choice12}");
                            Thread.Sleep(50);
                            m++;
                        }
                        byte pickpet = game.GetValidByteInput("[Answer:] ", 1, (byte)pets.Length);
                        Console.Beep();
                        Console.Clear();

                        string character_pet = Convert.ToString(pets.GetValue(pickpet - 1)) ?? "";
                        characterlist.Add(character_pet);

                        //Skill pets Code Parts with validation
                        game.ShowLoading("Analyzing Next...", 1000);
                        Console.Clear();
                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();
                        string[] skillpets = { "Water", "Fire", "Wind", "Electric" };

                        byte n = 1;

                        Console.WriteLine("\nPets Skill:");
                        foreach (var choice13 in skillpets)
                        {
                            Console.WriteLine($"[{n}]{choice13}");
                            Thread.Sleep(50);
                            n++;
                        }
                        byte pickPetSkill = game.GetValidByteInput("[Answer:] ", 1, (byte)skillpets.Length);
                        Console.Beep();
                        Console.Clear();

                        string character_PetSKill = Convert.ToString(skillpets.GetValue(pickPetSkill - 1)) ?? "";
                        characterlist.Add(character_PetSKill);

                        //Character Skill Code Parts with validation
                        game.ShowLoading("Analyzing Next...", 1000);
                        Console.Clear();
                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();
                        string[] characterPower = { "Water", "Fire", "Wind", "Electric" };

                        byte o = 1;

                        Console.WriteLine("\nCharacter Power:");
                        foreach (var choice14 in characterPower)
                        {
                            Console.WriteLine($"[{o}]{choice14}");
                            Thread.Sleep(50);
                            o++;
                        }
                        byte pickCharacterPower = game.GetValidByteInput("[Answer:] ", 1, (byte)characterPower.Length);
                        Console.Beep();
                        Console.Clear();

                        string character_Power = Convert.ToString(characterPower.GetValue(pickCharacterPower - 1)) ?? "";
                        characterlist.Add(character_Power);

                        // Potion Code parts with validation
                        game.ShowLoading("Analyzing Next...", 1000);
                        Console.Clear();
                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();
                        string[] Potion = { "Strength", "Speed", "Heal", "Defence", "Posion" };

                        byte q = 1;

                        Console.WriteLine("\nPotion:");
                        foreach (var choice15 in Potion)
                        {
                            Console.WriteLine($"[{q}]{choice15}");
                            Thread.Sleep(50);
                            q++;
                        }
                        byte pickPotion = game.GetValidByteInput("[Answer:] ", 1, (byte)Potion.Length);

                        Console.Beep();
                        Console.Clear();

                        string character_Potion = Convert.ToString(Potion.GetValue(pickPotion - 1)) ?? "";
                        characterlist.Add(character_Potion);

                        // Many potion you want

                        game.ShowLoading("Analyzing Next...", 1000);
                        Console.Clear();
                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();

                        int[] manypotion = { 1, 2, 3 };
                        byte z = 1;
                        Console.WriteLine("\nHow Many potion you want?:");
                        foreach (var choice18 in manypotion)
                        {
                            Console.WriteLine($"[{z}]{choice18}x");
                            Thread.Sleep(50);
                            z++;
                        }

                        byte manyPotion = game.GetValidByteInput("[Answer:] ", 1, (byte)manypotion.Length);
                        Console.Beep();
                        Console.Clear();
                        string character_manyPotion = Convert.ToString(manypotion.GetValue(manyPotion - 1)) ?? "";
                        characterlist.Add(character_manyPotion);

                        // Additional Item with validation
                        game.ShowLoading("Analyzing Next...", 1000);
                        Console.Clear();
                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();
                        string[] Item = { "Bomb", "Smoke Bomb", "Flash bomb", "Posion Bomb" };

                        byte r = 1;

                        Console.WriteLine("\nItem:");
                        foreach (var choice16 in Item)
                        {
                            Console.WriteLine($"[{r}]{choice16}");
                            Thread.Sleep(50);
                            r++;
                        }
                        byte pickItem = game.GetValidByteInput("[Answer:] ", 1, (byte)Item.Length);
                        Console.Beep();
                        Console.Clear();

                        string character_Item = Convert.ToString(Item.GetValue(pickItem - 1)) ?? "";
                        characterlist.Add(character_Item);

                        //Character Ultimate Code parts with validation
                        byte s = 1;

                        if (character_Power.ToLower().Equals("water"))
                        {
                            //Character Ultimate Water
                            game.ShowLoading("Analyzing Next...", 1000);
                            Console.Clear();
                            game.CharacterIdentity("\nYour character's name: ");
                            game.CharacterIdentity();
                            string[] ultimate = { "Flood Control", "Tsunami", "Water Burst", "Dragon Blust" };

                            Console.WriteLine("\nUltimate:");
                            foreach (var choice17 in ultimate)
                            {
                                Console.WriteLine($"[{s}]{choice17}");
                                Thread.Sleep(50);
                                s++;
                            }
                            byte pickUltimate = game.GetValidByteInput("[Answer:] ", 1, (byte)ultimate.Length);
                            Console.Beep();
                            Console.Clear();

                            string character_Ultimate = Convert.ToString(ultimate.GetValue(pickUltimate - 1)) ?? "";
                            characterlist.Add(character_Ultimate);
                        }

                        else if (character_Power.ToLower().Equals("fire"))
                        {
                            //Character Ultimate Fire
                            game.ShowLoading("Analyzing Next...", 1000);
                            Console.Clear();
                            game.CharacterIdentity("\nYour character's name: ");
                            game.CharacterIdentity();
                            string[] ultimate = { "Fire Dragon", "Fire Bomb", "Fire Ball", "Fire Flood" };

                            Console.WriteLine("\nUltimate:");
                            foreach (var choice17 in ultimate)
                            {
                                Console.WriteLine($"[{s}]{choice17}");
                                Thread.Sleep(50);
                                s++;
                            }
                            byte pickUltimate = game.GetValidByteInput("[Answer:] ", 1, (byte)ultimate.Length);
                            Console.Beep();
                            Console.Clear();

                            string character_Ultimate = Convert.ToString(ultimate.GetValue(pickUltimate - 1)) ?? "";
                            characterlist.Add(character_Ultimate);
                        }
                        else if (character_Power.ToLower().Equals("wind"))
                        {
                            //Character Ultimate Wind
                            game.ShowLoading("Analyzing Next...", 1000);
                            Console.Clear();
                            game.CharacterIdentity("\nYour character's name: ");
                            game.CharacterIdentity();

                            string[] ultimate = { "Tornado", "Wind Burst", "Air Blust", "Wind Slash" };

                            Console.WriteLine("\nUltimate:");
                            foreach (var choice17 in ultimate)
                            {
                                Console.WriteLine($"[{s}]{choice17}");
                                Thread.Sleep(50);
                                s++;
                            }
                            byte pickUltimate = game.GetValidByteInput("[Answer:] ", 1, (byte)ultimate.Length);
                            Console.Beep();
                            Console.Clear();

                            string character_Ultimate = Convert.ToString(ultimate.GetValue(pickUltimate - 1)) ?? "";
                            characterlist.Add(character_Ultimate);
                        }
                        else if (character_Power.ToLower().Equals("electric"))
                        {
                            // Character Ultimate electric
                            game.ShowLoading("Analyzing Next...", 1000);
                            Console.Clear();
                            game.CharacterIdentity("\nYour character's name: ");
                            game.CharacterIdentity();
                            string[] ultimate = { "Electric Shock", "Thunder Strike", "Electric Chain", "Static Trap" };

                            Console.WriteLine("\nUltimate:");
                            foreach (var choice17 in ultimate)
                            {
                                Console.WriteLine($"[{s}]{choice17}");
                                Thread.Sleep(50);
                                s++;
                            }


                            byte pickUltimate = game.GetValidByteInput("[Answer:] ", 1, (byte)ultimate.Length);
                            Console.Beep();
                            Console.Clear();

                            string character_Ultimate = Convert.ToString(ultimate.GetValue(pickUltimate - 1)) ?? "";
                            characterlist.Add(character_Ultimate);
                        }

                        //Combo Character and Pets
                        if (character_Power.ToLower().Equals("fire") && character_PetSKill.ToLower().Equals("water") || character_Power.ToLower().Equals("water") && character_PetSKill.ToLower().Equals("fire"))
                        {
                            Console.WriteLine("Combo Character + Pet: Steam");
                            characterlist.Add("Steam");
                        }
                        else if (character_Power.ToLower().Equals("fire") && character_PetSKill.ToLower().Equals("wind") || character_Power.ToLower().Equals("wind") && character_PetSKill.ToLower().Equals("fire"))
                        {
                            Console.WriteLine("Combo Character + Pet: Explosion");
                            characterlist.Add("Explosion");
                        }
                        else if (character_Power.ToLower().Equals("water") && character_PetSKill.ToLower().Equals("wind") || character_Power.ToLower().Equals("wind") && character_PetSKill.ToLower().Equals("water"))
                        {
                            Console.WriteLine("Combo Character + Pet: Ice");
                            characterlist.Add("Ice");
                        }
                        else if (character_Power.ToLower().Equals("fire") && character_PetSKill.ToLower().Equals("electric") || character_Power.ToLower().Equals("electric") && character_PetSKill.ToLower().Equals("fire"))
                        {
                            Console.WriteLine("Combo Character + Pet: Plasma");
                            characterlist.Add("Plasma");
                        }
                        else if (character_Power.ToLower().Equals("water") && character_PetSKill.ToLower().Equals("electric") || character_Power.ToLower().Equals("electric") && character_PetSKill.ToLower().Equals("water"))
                        {
                            Console.WriteLine("Combo Character + Pet: Storm");
                            characterlist.Add("Storm");
                        }
                        else
                        {
                            Console.WriteLine("Combo Character + Pet: No Possible Combo");
                            characterlist.Add("No Possible Combo Character and Pet");
                        }

                        game.ShowLoading("Analyzing Next...", 1000);
                        Console.Clear();
                        game.CharacterIdentity("\nYour character's name: ");
                        game.CharacterIdentity();

                        string result = game.ExtraHit();
                        Console.Beep();
                        Console.Clear();

                        characterlist.Add(result);

                        //Saving Game in DataBase
                        Console.WriteLine("================================");
                        dataBase.createdSuccess(characterlist, menu);
                        dataBase.DataBaseCreation(characterlist, game.getID(),game);


                        Console.WriteLine("==========================");

                        // Show loading when character creation is complete
                        game.ShowLoading("Finalizing character creation", 2000);

                        game.BlinkText("\nCharacter creation completed and saved!");
                        Console.WriteLine();

                        ConsoleKeyInfo consoleKeyInfo;
                        do
                        {
                            game.ClearLine();
                            Console.WriteLine("\n\nPress Enter key to return to main menu...");
                            consoleKeyInfo = Console.ReadKey();
                            Console.WriteLine();
                            Console.Beep();
                            if (consoleKeyInfo.Key!=ConsoleKey.Enter)
                            {
                                game.ClearLine();
                                Console.WriteLine("Error: Please Input Key Enter.....");
                                Thread.Sleep(2000);
                                game.ClearLine();
                            }

                        } while (consoleKeyInfo.Key != ConsoleKey.Enter);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"\nFormat Error during character creation: {ex.Message}");
                        Console.WriteLine("Returning to main menu...");
                        Thread.Sleep(3000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\nUnexpected Error during character creation: {ex.Message}");
                        Console.WriteLine("Returning to main menu...");
                        Thread.Sleep(3000);
                    }
                    finally
                    {
                        Console.WriteLine("Character creation process completed.");
                    }
                }
                // Menu option 2: LOAD GAME - Now just returns to menu
                else if (pick == 2)
                {

                    string[] LoadMenu = { "Select", "Update", "Delete", "BackMenu" };
                    try
                    {
                        byte count = 1;

                        foreach (var MenuLoad in LoadMenu)
                        {
                            Console.WriteLine($"[{count}]{MenuLoad}");
                            count++;
                        }
                        byte pickCType = game.GetValidByteInput("[Answer:] ", 1, Convert.ToByte(LoadMenu.Length));
                        Console.Beep();
                        Console.Clear();
                        switch (pickCType)
                        {
                            case 1:
                                dataBase.SelectDataBase(game);
                                break;
                            case 2:
                                dataBase.UpdateDataBase(game);
                                break;
                            case 3:
                                dataBase.DeleteDataBase(game);
                                break;
                            default:
                                break;
                        }

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Format Error in Load Game: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Unexpected Error in Load Game: {ex.Message}");
                    }
                    finally
                    {
                        Console.WriteLine("Load Game attempt completed.");
                    }
                }
                // Menu option 3: STORY MODE
                else if (pick == 3)
                {
                    game.StoryMode();
                }
                // Menu option 4: CREDITS
                else if (pick == 4)
                {
                    game.ShowCredits();
                }
                // Menu option 5: EXIT
                else if (pick == 5)
                {
                    main_menu = game.ExitGame();
                }

            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Main Menu Format Error: {ex.Message}");
                Thread.Sleep(3000);
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Main Menu Unexpected Error: {ex.Message}");
                Thread.Sleep(3000);
                Console.Clear();
            }
            finally
            {
                // This runs after every menu iteration
                Console.WriteLine("Menu iteration completed.");
            }
        }

        try
        {
            game.BlinkText("\nThank you for playing Ultimate Magical Rumble!");
            Thread.Sleep(2000);
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Final Message Format Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Final Message Unexpected Error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Game session ended.");
        }
    }
}


// DataBase Record Namin 
class SavingCharacterDataBase
{
    public void createdSuccess(List<string> characterlist, string[] menu)
    {
        Console.WriteLine("=========================");
        Console.WriteLine("Your Character Created Successfully!");
        Console.WriteLine();
        for (byte ii = 0; ii < characterlist.Count && ii < menu.Length; ii++)
        {
            Console.WriteLine($"{menu[ii]}{characterlist[ii]}");
        }
    }
    public void DataBaseCreation(List<string> CharacterList, int ID,Name game)
    {
        // SQL Server Connection
        string DataCharacter = @"Data Source=localhost\sqlexpress;Initial Catalog=GameCustomizeCharacter;Integrated Security=True;TrustServerCertificate=True;";
        DateTime date = DateTime.Now;

        try
        {
            using (SqlConnection connect = new SqlConnection(DataCharacter))
            {
                //Open Sql Connect
                connect.Open();
                Console.WriteLine("Connected and Saving Data");

                string insert = "INSERT INTO dbo.[Table_1]" +
                    "(DateandTime,UserName,UserID,Gender," +
                    "CharacterType,BodyType,ColorSkin,EyeColor,HairColor,HairStyle,FaceStyle," +
                    "EyeStyle,TshirtStyle,PantsStyle,Weapon,Pets,PetSkills,CharacterPower," +
                    "Potion,ManyPotion,Item,Ultimate,ComboCharacter,ExtraPoint)" +
                    "VALUES(@DateandTime,@UserName,@UserID,@Gender,@CharacterType,@BodyType,@ColorSkin,@EyeColor," +
                    "@HairColor,@HairStyle,@FaceStyle,@EyeStyle,@TshirtStyle,@PantsStyle,@Weapon," +
                    "@Pets,@PetSkills,@CharacterPower,@Potion,@ManyPotion,@Item,@Ultimate,@ComboCharacter,@ExtraPoint)";

                using (SqlCommand command = new SqlCommand(insert, connect))
                {
                    command.Parameters.AddWithValue("@DateandTime", date);
                    command.Parameters.AddWithValue("@UserName", CharacterList[0]);
                    command.Parameters.AddWithValue("@UserID", ID);
                    command.Parameters.AddWithValue("@Gender", CharacterList[2]);
                    command.Parameters.AddWithValue("@CharacterType", CharacterList[3]);
                    command.Parameters.AddWithValue("@BodyType", CharacterList[4]);
                    command.Parameters.AddWithValue("@ColorSkin", CharacterList[5]);
                    command.Parameters.AddWithValue("@EyeColor", CharacterList[6]);
                    command.Parameters.AddWithValue("@HairColor", CharacterList[7]);
                    command.Parameters.AddWithValue("@HairStyle", CharacterList[8]);
                    command.Parameters.AddWithValue("@FaceStyle", CharacterList[9]);
                    command.Parameters.AddWithValue("@EyeStyle", CharacterList[10]);
                    command.Parameters.AddWithValue("@TshirtStyle", CharacterList[11]);
                    command.Parameters.AddWithValue("@PantsStyle", CharacterList[12]);
                    command.Parameters.AddWithValue("@Weapon", CharacterList[13]);
                    command.Parameters.AddWithValue("@Pets", CharacterList[14]);
                    command.Parameters.AddWithValue("@PetSkills", CharacterList[15]);
                    command.Parameters.AddWithValue("@CharacterPower", CharacterList[16]);
                    command.Parameters.AddWithValue("@Potion", CharacterList[17]);
                    command.Parameters.AddWithValue("@ManyPotion", CharacterList[18]);
                    command.Parameters.AddWithValue("@Item", CharacterList[19]);
                    command.Parameters.AddWithValue("@Ultimate", CharacterList[20]);
                    command.Parameters.AddWithValue("@ComboCharacter", CharacterList[21]);
                    command.Parameters.AddWithValue("@ExtraPoint",game.getExtraHit());

                    command.ExecuteNonQuery();
                    Console.WriteLine("Complete Saving Data");
                }

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public void SelectDataBase(Name game)
    {
        // SQl Server Connection
        string DataCharacter = @"Data Source=localhost\sqlexpress;Initial Catalog=GameCustomizeCharacter;Integrated Security=True;TrustServerCertificate=True;";
        try
        {
            using (SqlConnection connect = new SqlConnection(DataCharacter))
            {
                // Open Sql Connect
                connect.Open();

                string select = "SELECT * FROM dbo.[Table_1]";
                using (SqlCommand command = new SqlCommand(select, connect))
                {
                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Console.WriteLine(dataReader["NumberofCharacter"] + "-User");
                        Console.WriteLine($"{dataReader["DateandTime"],-25}||{dataReader["UserName"].ToString(),-15}||{dataReader["UserID"],-15}||{dataReader["Gender"],-15}||{dataReader["CharacterType"],-15}");
                        Console.WriteLine($"{"",-25}||{dataReader["BodyType"],-15}||{dataReader["ColorSkin"],-15}||{dataReader["EyeColor"],-15}||{dataReader["HairColor"],-15}||{dataReader["HairStyle"],-15}");
                        Console.WriteLine($"{"",-25}||{dataReader["FaceStyle"],-15}||{dataReader["EyeStyle"],-15}||{dataReader["TshirtStyle"],-15}||{dataReader["PantsStyle"],-15}||{dataReader["Weapon"],-15}");
                        Console.WriteLine($"{"",-25}||{dataReader["Pets"],-15}||{dataReader["PetSkills"],-15}||{dataReader["CharacterPower"],-15}||{dataReader["Potion"],-15}||{dataReader["ManyPotion"],-15}");
                        Console.WriteLine($"{"",-25}||{dataReader["Item"],-15}||{dataReader["Ultimate"],-15}||{dataReader["ComboCharacter"],-15}||{dataReader["ExtraPoint"],-15}");
                        Console.WriteLine("=======================================");
                    }

                }

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine();
        ConsoleKeyInfo consoleKeyInfo;
        do
        {
            game.ClearLine();
            Console.WriteLine("Press Enter To Back MainMenu in game............");
            consoleKeyInfo = Console.ReadKey();
            Console.WriteLine();
            if (consoleKeyInfo.Key != ConsoleKey.Enter)
            {
                game.ClearLine();
                Console.WriteLine("Error:Please Input Enter.......");
            }
            Thread.Sleep(2000);
            game.ClearLine();
            Console.Beep();
        } while (consoleKeyInfo.Key != ConsoleKey.Enter);
    }
    public void UpdateDataBase(Name game)
    {
        while (true)
        {
            string DataCharacter = @"Data Source=localhost\sqlexpress;Initial Catalog=GameCustomizeCharacter;Integrated Security=True;TrustServerCertificate=True;";
            try
            {


                using (SqlConnection connect = new SqlConnection(DataCharacter))
                {
                    // Open Sql Sonnect
                    connect.Open();

                    string select = "SELECT * FROM dbo.[Table_1]";
                    using (SqlCommand command = new SqlCommand(select, connect))
                    {

                        SqlDataReader dataReader = command.ExecuteReader();

                        Console.WriteLine();
                        Console.WriteLine("Update Change Name:");
                        Console.WriteLine("---------------------");
                        Console.WriteLine("[0]Back");
                        Console.WriteLine("---------------------");
                        while (dataReader.Read())
                        {
                            Console.WriteLine($"ID User:[{dataReader["NumberofCharacter"]}] || Name User:{dataReader["UserName"]}");

                        }
                        // Data Reader Closing
                        dataReader.Close();

                        Console.WriteLine("[Answer:]");
                        int pickChoice = Convert.ToInt32(Console.ReadLine());
                        Console.Beep();
                        if (pickChoice == 0)
                        {
                            break;
                        }
                        string selected = "SELECT * FROM dbo.[Table_1] WHERE NumberofCharacter = @NumberofCharacter";

                        string update = "UPDATE dbo.[Table_1] SET UserName = @UserName WHERE NumberofCharacter = " + pickChoice;

                        using (SqlCommand comm = new SqlCommand(selected, connect))
                        {

                            comm.Parameters.AddWithValue(@"NumberofCharacter", pickChoice);

                            SqlDataReader read = comm.ExecuteReader();

                            if (read.HasRows)
                            {
                                read.Close();

                                using (SqlCommand com = new SqlCommand(update, connect))
                                {
                                    Console.WriteLine("New Name:");
                                    string choice = Console.ReadLine()!;
                                    Console.Beep();
                                    com.Parameters.AddWithValue(@"UserName", choice);
                                    com.ExecuteNonQuery();
                                    Console.WriteLine("Updated Name..................");
                                    break;
                                }
                            }
                            else
                            {
                                game.ClearLine();
                                Console.WriteLine("Please Use The Right User ID");
                                Thread.Sleep(2000);
                                game.ClearLine();
                                Console.Clear();
                                
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine();
        ConsoleKeyInfo consoleKeyInfo;

        do
        {
            game.ClearLine();
            Console.WriteLine("Press Enter To Back MainMenu in game............");
            consoleKeyInfo = Console.ReadKey();
            Console.WriteLine();
            if (consoleKeyInfo.Key != ConsoleKey.Enter)
            {
                game.ClearLine();
                Console.WriteLine("Error:Please Input Enter.......");
                Thread.Sleep(2000);
            }

            Console.Beep();
            game.ClearLine();
        } while (consoleKeyInfo.Key != ConsoleKey.Enter);


    }
    public void DeleteDataBase(Name game)
    {
        while (true)
        {
            string DataCharacter = @"Data Source=localhost\sqlexpress;Initial Catalog=GameCustomizeCharacter;Integrated Security=True;TrustServerCertificate=True;";
            try
            {

                using (SqlConnection connect = new SqlConnection(DataCharacter))
                {
                    // Open Sql Connect
                    connect.Open();

                    string select = "SELECT * FROM dbo.[Table_1]";
                    using (SqlCommand command = new SqlCommand(select, connect))
                    {

                        SqlDataReader dataReader = command.ExecuteReader();

                        Console.WriteLine();
                        Console.WriteLine("Delete Name:");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("[0]Back");
                        Console.WriteLine("--------------------------");
                        while (dataReader.Read())
                        {
                            Console.WriteLine($"ID User:[{dataReader["NumberofCharacter"]}] || User Name:{dataReader["UserName"]}");

                        }
                        
                        //Not forgot to erase becuase no reader closer 
                        dataReader.Close();


                        Console.Write("[Answer:]");
                        int pickChoice = Convert.ToInt32(Console.ReadLine());
                        if (pickChoice == 0)
                        {
                            break;
                        }
                        Console.Beep();
                        Console.WriteLine();
                        string selected = "SELECT * FROM dbo.[Table_1] WHERE NumberofCharacter = @NumberofCharacter";

                        string delete = "DELETE FROM dbo.[Table_1] WHERE NumberofCharacter = @NumberofCharacter";

                        using (SqlCommand comm = new SqlCommand(selected, connect))
                        {
                            comm.Parameters.AddWithValue(@"NumberofCharacter", pickChoice);

                            SqlDataReader read = comm.ExecuteReader();

                            if (read.HasRows)
                            {
                                read.Close();
                                Console.WriteLine("Do you want Delete this (Yes or No)?");
                                while (true)
                                {
              
                                    string input = Console.ReadLine()!.Trim().ToLower();
                                    Console.Beep();
                                   

                                    if (input == "yes")
                                    {
                                        using (SqlCommand com = new SqlCommand(delete, connect))
                                        {
                                            com.Parameters.AddWithValue(@"NumberofCharacter", pickChoice);
                                            com.ExecuteNonQuery();
                                            Console.WriteLine("Deleting Data.........................");
                                            break;
                                        }
                                    }
                                    else if (input == "no")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        game.ClearLine();
                                        Console.WriteLine("Error: Please input yes or no");
                                        Thread.Sleep(2000);
                                        game.ClearLine();
                                    }
                                }
                            }
                            else
                            {

                                Console.WriteLine("Please Use The Right User ID");
                                Thread.Sleep(2000);
                                read.Close();
                            }
                        }


                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(2000);
            }
            Console.Clear();
        }

        Console.WriteLine();
        ConsoleKeyInfo consoleKeyInfo;
        do
        {
            game.ClearLine();
            Console.WriteLine("Press Enter To Back MainMenu in game............");
            consoleKeyInfo = Console.ReadKey();
            Console.WriteLine();
             if(consoleKeyInfo.Key != ConsoleKey.Enter)
            {
                game.ClearLine();
                Console.WriteLine("Error:Please Input Enter....");
                Thread.Sleep(2000);
                game.ClearLine();
            }
            Console.Beep();
        } while (consoleKeyInfo.Key != ConsoleKey.Enter);
    }
}


