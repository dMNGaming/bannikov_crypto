using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace bannikov_crypto
{
    class play_fear
    {
        private string str;
        private string key1;
        private string language;
        private string alphabet_ru = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private string alphabet_en = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        public char[,] ruResultSquare;
        public char[,] enResultSquare;
        public string[] ruStrSplited;
        public string[] enStrSplited;

        public play_fear(string Str, string Key1, string Language)
        {
            str = Str;
            key1 = Key1;
            language = Language;

        }


        public void takeCryptoResult()
        {

            if (language == "ru")
            {
                //получение таблицы из ключа и алфавита
                char[,] playFearAlphabetRu = new char[8, 4];
                key1 = new string(key1.Distinct().ToArray());//удаление повторяющихся символов в ключе
                str = Regex.Replace(str, "[^а-яА-Я]", "");
                key1 = Regex.Replace(key1, "[^а-яА-Я]", "");
                str = str.ToUpper();
                key1 = key1.ToUpper();

                for (int i = 0; i < key1.Length; ++i)//удаление из алфавита тех букв, которые имеются в ключе
                {
                    int tmp = alphabet_ru.IndexOf(key1[i]);
                    if(tmp != -1)
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

                            playFearAlphabetRu[i, j] = key1[k];
                            k++;
                            check1--;
                        }
                        else
                        {
                            playFearAlphabetRu[i, j] = alphabet_ru[m];
                            m++;
                        }
                    }
                }
                ruResultSquare = playFearAlphabetRu;

                //разделение строки на биграммы
                str = new string(str.Replace(" ", "").ToArray());//удаление пробелов в строке

                for(int i = 0; i < str.Length; ++i)
                {
                    if (i % 2 != 0)
                    {
                        if(str[i] == str[i-1])
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
                //получение таблицы из ключа и алфавита
                char[,] playFearAlphabetEn = new char[5, 5];
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

                            playFearAlphabetEn[i, j] = key1[k];
                            k++;
                            check1--;
                        }
                        else
                        {
                            playFearAlphabetEn[i, j] = alphabet_en[m];
                            m++;
                        }
                    }
                }
                enResultSquare = playFearAlphabetEn;

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
            if(language == "ru")
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
                            if (ruResultSquare[i, j] == s2)
                            {
                                i2 = i;
                                j2 = j;
                            }
                        }
                    }
                    if (i1 == i2)//смещаются на букву вправо
                    {
                        j1++;
                        if (j1 == 4)
                            j1 = 0;
                        j2++;
                        if (j2 == 4)
                            j2 = 0;

                    }
                    else
                    if (j1 == j2)//смещаются на букву вниз
                    {
                        i1++;
                        if (i1 == 8)
                            i1 = 0;
                        i2++;
                        if (i2 == 8)
                            i2 = 0;
                    }
                    else//квадрат
                    {
                        if (i1 < i2 && j1 < j2)//БЙ - ВИ
                        {
                            int tmp = j2;
                            j2 = j1;
                            j1 = tmp;
                        }
                        else
                        if (i1 < i2 && j1 > j2)//ВИ - ЙБ
                        {
                            int tmp = i1;
                            i1 = i2;
                            i2 = tmp;
                        }
                        else
                        if (i1 > i2 && j1 < j2)//ИВ - БЙ
                        {
                            int tmp = i2;
                            i2 = i1;
                            i1 = tmp;
                        }
                        else
                        if (i1 > i2 && j1 > j2)
                        {
                            int tmp = j2;
                            j2 = j1;
                            j1 = tmp;
                        }
                    }
                    /*1  2

                      4  3*/
                    ruStrSplited[k] = string.Empty;
                    ruStrSplited[k] += (char)ruResultSquare[i1, j1] + "" + (char)ruResultSquare[i2, j2];
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
                    if (i1 == i2)//смещаются на букву вправо
                    {
                        j1++;
                        if (j1 == 5)
                            j1 = 0;
                        j2++;
                        if (j2 == 5)
                            j2 = 0;

                    }
                    else
                    if (j1 == j2)//смещаются на букву вниз
                    {
                        i1++;
                        if (i1 == 5)
                            i1 = 0;
                        i2++;
                        if (i2 == 5)
                            i2 = 0;
                    }
                    else//квадрат
                    {
                        if (i1 < i2 && j1 < j2)//БЙ - ВИ
                        {
                            int tmp = j2;
                            j2 = j1;
                            j1 = tmp;
                        }
                        else
                        if (i1 < i2 && j1 > j2)//ВИ - ЙБ
                        {
                            int tmp = i1;
                            i1 = i2;
                            i2 = tmp;
                        }
                        else
                        if (i1 > i2 && j1 < j2)//ИВ - БЙ
                        {
                            int tmp = i2;
                            i2 = i1;
                            i1 = tmp;
                        }
                        else
                        if (i1 > i2 && j1 > j2)
                        {
                            int tmp = j2;
                            j2 = j1;
                            j1 = tmp;
                        }
                    }
                    /*1  2

                      4  3*/
                    enStrSplited[k] = string.Empty;
                    enStrSplited[k] += (char)enResultSquare[i1, j1] + "" + (char)enResultSquare[i2, j2];
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
                            if (ruResultSquare[i, j] == s1)
                            {
                                i1 = i;
                                j1 = j;
                            }
                            if (ruResultSquare[i, j] == s2)
                            {
                                i2 = i;
                                j2 = j;
                            }
                        }
                    }
                    if (i1 == i2)//смещаются на букву вправо
                    {
                        j1--;
                        if (j1 == -1)
                            j1 = 3;
                        j2--;
                        if (j2 == -1)
                            j2 = 3;

                    }
                    else
                    if (j1 == j2)//смещаются на букву вниз
                    {
                        i1--;
                        if (i1 == -1)
                            i1 = 7;
                        i2--;
                        if (i2 == -1)
                            i2 = 7;
                    }
                    else//квадрат
                    {
                        if (i1 < i2 && j1 < j2)//БЙ - ВИ
                        {
                            int tmp = i1;
                            i1 = i2;
                            i2 = tmp;
                        }
                        else
                        if (i1 < i2 && j1 > j2)//ВИ - ЙБ
                        {
                            int tmp = j2;
                            j2 = j1;
                            j1 = tmp;
                        }
                        else
                        if (i1 > i2 && j1 < j2)//ИВ - БЙ
                        {
                            int tmp = j1;
                            j1 = j2;
                            j2 = tmp;
                        }
                        else
                        if (i1 > i2 && j1 > j2)
                        {
                            int tmp = i1;
                            i1 = i2;
                            i2 = tmp;
                        }
                    }
                    /*1  2

                      4  3*/
                    ruStrSplited[k] = string.Empty;
                    ruStrSplited[k] += (char)ruResultSquare[i1, j1] + "" + (char)ruResultSquare[i2, j2];
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
                    if (i1 == i2)//смещаются на букву вправо
                    {
                        j1--;
                        if (j1 == -1)
                            j1 = 4;
                        j2--;
                        if (j2 == -1)
                            j2 = 4;

                    }
                    else
                    if (j1 == j2)//смещаются на букву вниз
                    {
                        i1--;
                        if (i1 == -1)
                            i1 = 4;
                        i2--;
                        if (i2 == -1)
                            i2 = 4;
                    }
                    else//квадрат
                    {
                        if (i1 < i2 && j1 < j2)//БЙ - ВИ
                        {
                            int tmp = i1;
                            i1 = i2;
                            i2 = tmp;
                        }
                        else
                        if (i1 < i2 && j1 > j2)//ВИ - ЙБ
                        {
                            int tmp = j2;
                            j2 = j1;
                            j1 = tmp;
                        }
                        else
                        if (i1 > i2 && j1 < j2)//ИВ - БЙ
                        {
                            int tmp = j1;
                            j1 = j2;
                            j2 = tmp;
                        }
                        else
                        if (i1 > i2 && j1 > j2)
                        {
                            int tmp = i1;
                            i1 = i2;
                            i2 = tmp;
                        }
                    }
                    /*1  2

                      4  3*/
                    enStrSplited[k] = string.Empty;
                    enStrSplited[k] += (char)enResultSquare[i1, j1] + "" + (char)enResultSquare[i2, j2];
                }
            }
        }
    }
    
}
