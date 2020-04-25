using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace bannikov_crypto
{
    class white_stone
    {
        private string str;
        private string key1;
        private string key2;
        private string language;
        private string alphabet_ru = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private string alphabet_ru1 = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private string alphabet_en = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        private string alphabet_en1 = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        public char[,] ruResultSquare;
        public char[,] ruResultSquare1;
        public char[,] enResultSquare;
        public char[,] enResultSquare1;
        public string[] ruStrSplited;
        public string[] enStrSplited;

        public white_stone(string Str, string Key1, string Key2, string Language)
        {
            str = Str;
            key1 = Key1;
            key2 = Key2;
            language = Language;

        }


        public void takeCryptoResult()
        {

            if (language == "ru")
            {
                //1 получение таблицы из ключа и алфавита
                char[,] whiteStoneAlphabetRu = new char[8, 4];
                key1 = new string(key1.Distinct().ToArray());//удаление повторяющихся символов в ключе
                str = Regex.Replace(str, "[^а-яА-Я]", "");
                key1 = Regex.Replace(key1, "[^а-яА-Я]", "");
                str = str.ToUpper();
                key1 = key1.ToUpper();

                for (int i = 0; i < key1.Length; ++i)//удаление из алфавита тех букв, которые имеются в ключе
                {
                    int tmp = alphabet_ru.IndexOf(key1[i]);
                    if (tmp != -1)
                    {
                        alphabet_ru = alphabet_ru.Remove(tmp, 1);
                    }
                }
                int check1 = key1.Length;
                int check2 = alphabet_ru.Length;

                for (int i = 0, k = 0, m = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 4; ++j)
                    {

                        if (check1 != 0)
                        {

                            whiteStoneAlphabetRu[i, j] = key1[k];
                            k++;
                            check1--;
                        }
                        else
                        {
                            whiteStoneAlphabetRu[i, j] = alphabet_ru[m];
                            m++;
                        }
                    }
                }
                ruResultSquare = whiteStoneAlphabetRu;
                //2
                char[,] whiteStoneAlphabetRu1 = new char[8, 4];
                key2 = new string(key2.Distinct().ToArray());//удаление повторяющихся символов в ключе
                //str = Regex.Replace(str, "[^а-яА-Я]", "");
                key2 = Regex.Replace(key2, "[^а-яА-Я]", "");
                //str = str.ToUpper();
                key2 = key2.ToUpper();

                for (int i = 0; i < key2.Length; ++i)//удаление из алфавита тех букв, которые имеются в ключе
                {
                    int tmp = alphabet_ru1.IndexOf(key2[i]);
                    if (tmp != -1)
                    {
                        alphabet_ru1 = alphabet_ru1.Remove(tmp, 1);
                    }
                }
                check1 = key2.Length;
                check2 = alphabet_ru1.Length;

                for (int i = 0, k = 0, m = 0; i < 8; ++i)
                {
                    for (int j = 0; j < 4; ++j)
                    {

                        if (check1 != 0)
                        {

                            whiteStoneAlphabetRu1[i, j] = key2[k];
                            k++;
                            check1--;
                        }
                        else
                        {
                            whiteStoneAlphabetRu1[i, j] = alphabet_ru1[m];
                            m++;
                        }
                    }
                }
                ruResultSquare1 = whiteStoneAlphabetRu1;

                //разделение строки на биграммы
                str = new string(str.Replace(" ", "").ToArray());//удаление пробелов в строке

                for (int i = 0; i < str.Length; ++i)
                {
                    if (i % 2 != 0)
                    {
                        if (str[i] == str[i - 1])
                        {
                            str = str.Insert(i, "Я");
                        }
                    }
                }

                if (str.Length % 2 != 0)//добавление в конец символа, если кол-во эл-тов нечетное
                {
                    str += "Я";
                }
                string[] strSplited = new string[str.Length / 2];

                for (int i = 0, k = 0; i < str.Length; i += 2)
                {
                    strSplited[k] = str.Substring(i, 2);
                    k++;
                }

                ruStrSplited = strSplited;



            }
            else
            {
                //1 получение таблицы из ключа и алфавита
                char[,] whiteStoneAlphabetEn = new char[5, 5];
                key1 = new string(key1.Distinct().ToArray());//удаление повторяющихся символов в ключе
                str = Regex.Replace(str, "[^a-zA-Z]", "");
                key1 = Regex.Replace(key1, "[^a-zA-Z]", "");
                str = str.ToUpper();
                key1 = key1.ToUpper();

                for (int i = 0; i < key1.Length; ++i)//удаление из алфавита тех букв, которые имеются в ключе
                {
                    int tmp = alphabet_en.IndexOf(key1[i]);
                    if (tmp != -1)
                    {
                        alphabet_en = alphabet_en.Remove(tmp, 1);
                    }
                }
                int check1 = key1.Length;
                int check2 = alphabet_en.Length;

                for (int i = 0, k = 0, m = 0; i < 5; ++i)
                {
                    for (int j = 0; j < 5; ++j)
                    {

                        if (check1 != 0)
                        {

                            whiteStoneAlphabetEn[i, j] = key1[k];
                            k++;
                            check1--;
                        }
                        else
                        {
                            whiteStoneAlphabetEn[i, j] = alphabet_en[m];
                            m++;
                        }
                    }
                }
                enResultSquare = whiteStoneAlphabetEn;
                //2
                char[,] whiteStoneAlphabetEn1 = new char[5, 5];
                key2 = new string(key2.Distinct().ToArray());//удаление повторяющихся символов в ключе
                //str = Regex.Replace(str, "[^a-zA-Z]", "");
                key2 = Regex.Replace(key2, "[^a-zA-Z]", "");
                //str = str.ToUpper();
                key2 = key2.ToUpper();

                for (int i = 0; i < key2.Length; ++i)//удаление из алфавита тех букв, которые имеются в ключе
                {
                    int tmp = alphabet_en1.IndexOf(key2[i]);
                    if (tmp != -1)
                    {
                        alphabet_en1 = alphabet_en1.Remove(tmp, 1);
                    }
                }
                check1 = key2.Length;
                check2 = alphabet_en1.Length;

                for (int i = 0, k = 0, m = 0; i < 5; ++i)
                {
                    for (int j = 0; j < 5; ++j)
                    {

                        if (check1 != 0)
                        {

                            whiteStoneAlphabetEn1[i, j] = key2[k];
                            k++;
                            check1--;
                        }
                        else
                        {
                            whiteStoneAlphabetEn1[i, j] = alphabet_en1[m];
                            m++;
                        }
                    }
                }
                enResultSquare1 = whiteStoneAlphabetEn1;

                //разделение строки на биграммы
                str = new string(str.Replace(" ", "").ToArray());//удаление пробелов в строке

                for (int i = 0; i < str.Length; ++i)
                {
                    if (i % 2 != 0)
                    {
                        if (str[i] == str[i - 1])
                        {
                            str = str.Insert(i, "X");
                        }
                    }
                }

                if (str.Length % 2 != 0)//добавление в конец символа, если кол-во эл-тов нечетное
                {
                    str += "X";
                }
                string[] strSplited = new string[str.Length / 2];

                for (int i = 0, k = 0; i < str.Length; i += 2)
                {
                    strSplited[k] = str.Substring(i, 2);
                    k++;
                }

                enStrSplited = strSplited;



            }
        }

        public void getCrypto()
        {
            if (language == "ru")
            {
                //шифрование биграмм
                int i1 = 0, i2 = 0, j1 = 0, j2 = 0;
                for (int k = 0; k < ruStrSplited.Length; ++k)
                {
                    char s1 = ruStrSplited[k][0];
                    char s2 = ruStrSplited[k][1];
                    for (int i = 0; i < 8; ++i)
                    {
                        for (int j = 0; j < 4; ++j)
                        {
                            if (ruResultSquare[i, j] == s1)
                            {
                                i1 = i;
                                j1 = j;
                            }
                            if (ruResultSquare1[i, j] == s2)
                            {
                                i2 = i;
                                j2 = j;
                            }
                        }
                    }
                    if (i1 == i2)//смещаются на букву вправо+
                    {
                        j1++;
                        if (j1 == 4)
                            j1 = 0;
                        j2++;
                        if (j2 == 4)
                            j2 = 0;
                        ruStrSplited[k] = string.Empty;
                        ruStrSplited[k] += (char)ruResultSquare[i1, j1] + "" + (char)ruResultSquare1[i2, j2];

                    }
                    else//квадрат
                    {
                        if (i1 > i2 && j1 == j2)
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare[i2, j1] + "" + (char)ruResultSquare1[i1, j2];
                        }
                        else
                        if (i1 < i2 && j1 == j2)
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare1[i1, j2] + "" + (char)ruResultSquare[i2, j1];
                        }
                        else
                        if (i1 < i2 && j1 < j2)//ЕТ - ЖС+
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare1[i1, j2] + "" + (char)ruResultSquare[i2, j1];
                        }
                        else
                        if (i1 < i2 && j1 > j2)//ВЕ - БЖ+
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare1[i1, j2] + "" + (char)ruResultSquare[i2, j1];
                        }
                        else
                        if (i1 > i2 && j1 < j2)//ЖБ - ВЕ
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare[i2, j1] + "" + (char)ruResultSquare1[i1, j2];
                        }
                        else
                        if (i1 > i2 && j1 > j2)//ЕВ - БЖ
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare[i2, j1] + "" + (char)ruResultSquare1[i1, j2];
                        }
                    }
                }
            }
            else
            {
                //шифрование биграмм
                int i1 = 0, i2 = 0, j1 = 0, j2 = 0;
                for (int k = 0; k < enStrSplited.Length; ++k)
                {
                    char s1 = enStrSplited[k][0];
                    char s2 = enStrSplited[k][1];
                    for (int i = 0; i < 5; ++i)
                    {
                        for (int j = 0; j < 5; ++j)
                        {
                            if (enResultSquare[i, j] == s1)
                            {
                                i1 = i;
                                j1 = j;
                            }
                            if (enResultSquare[i, j] == s2)
                            {
                                i2 = i;
                                j2 = j;
                            }
                        }
                    }
                    if (i1 == i2)//смещаются на букву вправо+
                    {
                        j1++;
                        if (j1 == 5)
                            j1 = 0;
                        j2++;
                        if (j2 == 5)
                            j2 = 0;
                        enStrSplited[k] = string.Empty;
                        enStrSplited[k] += (char)enResultSquare[i1, j1] + "" + (char)enResultSquare1[i2, j2];

                    }
                    else//квадрат
                    {
                        if (i1 > i2 && j1 == j2)
                        {
                            enStrSplited[k] = string.Empty;
                            enStrSplited[k] += (char)enResultSquare[i2, j1] + "" + (char)enResultSquare1[i1, j2];
                        }
                        else
                        if (i1 < i2 && j1 == j2)
                        {
                            enStrSplited[k] = string.Empty;
                            enStrSplited[k] += (char)enResultSquare1[i1, j2] + "" + (char)enResultSquare[i2, j1];
                        }
                        else
                        if (i1 < i2 && j1 < j2)//ЕТ - ЖС+
                        {
                            enStrSplited[k] = string.Empty;
                            enStrSplited[k] += (char)enResultSquare1[i1, j2] + "" + (char)enResultSquare[i2, j1];
                        }
                        else
                        if (i1 < i2 && j1 > j2)//ВЕ - БЖ+
                        {
                            enStrSplited[k] = string.Empty;
                            enStrSplited[k] += (char)enResultSquare1[i1, j2] + "" + (char)enResultSquare[i2, j1];
                        }
                        else
                        if (i1 > i2 && j1 < j2)//ЖБ - ВЕ
                        {
                            enStrSplited[k] = string.Empty;
                            enStrSplited[k] += (char)enResultSquare[i2, j1] + "" + (char)enResultSquare1[i1, j2];
                        }
                        else
                        if (i1 > i2 && j1 > j2)//ЕВ - БЖ
                        {
                            enStrSplited[k] = string.Empty;
                            enStrSplited[k] += (char)enResultSquare[i2, j1] + "" + (char)enResultSquare1[i1, j2];
                        }
                    }
                }
            }
        }

        public void takeDeCrypto()
        {
            if (language == "ru")
            {
                //шифрование биграмм
                int i1 = 0, i2 = 0, j1 = 0, j2 = 0;
                for (int k = 0; k < ruStrSplited.Length; ++k)
                {
                    char s1 = ruStrSplited[k][0];
                    char s2 = ruStrSplited[k][1];
                    for (int i = 0; i < 8; ++i)
                    {
                        for (int j = 0; j < 4; ++j)
                        {
                            if (ruResultSquare[i, j] == s2)
                            {
                                i1 = i;
                                j1 = j;
                            }
                            if (ruResultSquare1[i, j] == s1)
                            {
                                i2 = i;
                                j2 = j;
                            }
                        }
                    }
                    /*if (i1 == i2)//смещаются на букву вправо+
                    {
                        j1--;
                        if (j1 == -1)
                            j1 = 3;
                        j2--;
                        if (j2 == -1)
                            j2 = 3;
                        ruStrSplited[k] = string.Empty;
                        ruStrSplited[k] += (char)ruResultSquare[i1, j1] + "" + (char)ruResultSquare1[i2, j2];

                    }
                    else//квадрат
                    {
                        if (i1 < i2 && j1 == j2)//ид-ид
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare[i2, j1] + "" +(char)ruResultSquare1[i1, j2];
                        }
                        else
                        if (i1 > i2 && j1 == j2)//ди-ид
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare[i2, j1] + "" + (char)ruResultSquare1[i1, j2];
                        }
                        else
                        if (i1 > i2 && j1 > j2)//ЕТ - ЖС+
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare[i2, j1] + "" + (char)ruResultSquare1[i1, j2];
                        }
                        else
                        if (i1 > i2 && j1 < j2)//ВЕ - БЖ+
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare[i2, j1] + "" + (char)ruResultSquare1[i1, j2];
                        }
                        else
                        if (i1 < i2 && j1 > j2)//ЖБ - ВЕ
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare[i2, j1] + "" + (char)ruResultSquare1[i1, j2];
                        }
                        else
                        if (i1 < i2 && j1 < j2)//ЕВ - БЖ   РПИВ
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] +=(char)ruResultSquare1[i2, j1]+ "" + (char)ruResultSquare[i1, j2];
                        }*/
                    if (i1 == i2)//смещаются на букву вправо+
                    {
                        j1++;
                        if (j1 == 4)
                            j1 = 0;
                        j2++;
                        if (j2 == 4)
                            j2 = 0;
                        ruStrSplited[k] = string.Empty;
                        ruStrSplited[k] += (char)ruResultSquare[i1, j1] + "" + (char)ruResultSquare1[i2, j2];

                    }
                    else//квадрат
                    {
                        if (i1 > i2 && j1 == j2)
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare[i2, j1] + "" + (char)ruResultSquare1[i1, j2];
                        }
                        else
                        if (i1 < i2 && j1 == j2)
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare1[i1, j2] + "" + (char)ruResultSquare[i2, j1];
                        }
                        else
                        if (i1 < i2 && j1 < j2)//ЕТ - ЖС+
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare1[i1, j2] + "" + (char)ruResultSquare[i2, j1];
                        }
                        else
                        if (i1 < i2 && j1 > j2)//ВЕ - БЖ+
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare1[i1, j2] + "" + (char)ruResultSquare[i2, j1];
                        }
                        else
                        if (i1 > i2 && j1 < j2)//ЖБ - ВЕ
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare[i2, j1] + "" + (char)ruResultSquare1[i1, j2];
                        }
                        else
                        if (i1 > i2 && j1 > j2)//ЕВ - БЖ
                        {
                            ruStrSplited[k] = string.Empty;
                            ruStrSplited[k] += (char)ruResultSquare1[i1, j2] + "" + (char)ruResultSquare[i2, j1];
                        }
                    }
                }
            }
            else
            {
                //шифрование биграмм
                int i1 = 0, i2 = 0, j1 = 0, j2 = 0;
                for (int k = 0; k < enStrSplited.Length; ++k)
                {
                    char s1 = enStrSplited[k][0];
                    char s2 = enStrSplited[k][1];
                    for (int i = 0; i < 5; ++i)
                    {
                        for (int j = 0; j < 5; ++j)
                        {
                            if (enResultSquare[i, j] == s1)
                            {
                                i1 = i;
                                j1 = j;
                            }
                            if (enResultSquare[i, j] == s2)
                            {
                                i2 = i;
                                j2 = j;
                            }
                        }
                    }
                    if (i1 == i2)//смещаются на букву вправо+
                    {
                        j1--;
                        if (j1 == -1)
                            j1 = 4;
                        j2--;
                        if (j2 == -1)
                            j2 = 4;
                        enStrSplited[k] = string.Empty;
                        enStrSplited[k] += (char)enResultSquare[i1, j1] + "" + (char)enResultSquare1[i2, j2];

                    }
                    else//квадрат
                    {
                        if (i1 < i2 && j1 == j2)//ид-ид
                        {
                            enStrSplited[k] = string.Empty;
                            enStrSplited[k] += (char)enResultSquare[i2, j1] + "" + (char)enResultSquare1[i1, j2];
                        }
                        else
                        if (i1 > i2 && j1 == j2)//ди-ид
                        {
                            enStrSplited[k] = string.Empty;
                            enStrSplited[k] += (char)enResultSquare1[i1, j2] + "" + (char)enResultSquare[i2, j1];
                        }
                        else
                        if (i1 > i2 && j1 > j2)//ЕТ - ЖС+
                        {
                            enStrSplited[k] = string.Empty;
                            enStrSplited[k] += (char)enResultSquare1[i1, j2] + "" + (char)enResultSquare[i2, j1];
                        }
                        else
                        if (i1 > i2 && j1 < j2)//ВЕ - БЖ+
                        {
                            enStrSplited[k] = string.Empty;
                            enStrSplited[k] += (char)enResultSquare1[i1, j2] + "" + (char)enResultSquare[i2, j1];
                        }
                        else
                        if (i1 < i2 && j1 > j2)//ЖБ - ВЕ
                        {
                            enStrSplited[k] = string.Empty;
                            enStrSplited[k] += (char)enResultSquare[i2, j1] + "" + (char)enResultSquare1[i1, j2];
                        }
                        else
                        if (i1 < i2 && j1 < j2)//ЕВ - БЖ
                        {
                            enStrSplited[k] = string.Empty;
                            enStrSplited[k] += (char)enResultSquare1[i1, j2] + "" + (char)enResultSquare[i2, j1];
                        }
                    }
                }
            }
        }
    }
}
