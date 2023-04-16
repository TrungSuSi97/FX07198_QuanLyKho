using Microsoft.VisualBasic;

namespace TPH.LIS.Common.Barcode
{
    public class Code128
    {
        public string Get_128Code(string inputString)
        {
            var functionReturnValue = string.Empty;
            //V 2.0.0
            //Parametres : une chaine
            //Parameters : a string
            //Retour : * une chaine qui, affichee avec la police CODE128.TTF, donne le code barre
            //         * une chaine vide si parametre fourni incorrect
            //Return : * a string which give the bar code when it is dispayed with CODE128.TTF font
            //         * an empty string if the supplied parameter is no good
            int i = 0;
            var checksum = 0;
            var mini = 0;
            var dummy = 0;
            var tableB = false;
            if (inputString.Length > 0)
            {
                //Verifier si caracteres valides
                //Check for valid characters
                for (i = 1; i <= inputString.Length; i++)
                {
                    var charNum = Strings.Asc(Strings.Mid(inputString, i, 1));
                    if ((charNum >= 32 && charNum <= 126) || charNum == 203)
                    {
                        //Do nothing
                    }
                    else
                    {
                        i = 0;
                        break;
                    }
                }
                //Calculer la chaine de code en optimisant l'usage des tables B et C
                //Calculation of the code string with optimized use of tables B and C
                functionReturnValue = string.Empty;
                tableB = true;
                if (i > 0)
                {
                    i = 1;
                    //i% devient l'index sur la chaine / i% become the string index
                    while (i <= inputString.Length)
                    {
                        if (tableB)
                        {
                            //Voir si interessant de passer en table C / See if interesting to switch to table C
                            //Oui pour 4 chiffres au debut ou a la fin, sinon pour 6 chiffres / yes for 4 digits at start or end, else if 6 digits
                            mini = (i == 1 | i + 3 == Strings.Len(inputString) ? 4 : 6);
                            mini = TestNum(i, mini, inputString);
                            //Choix table C / Choice of table C
                            if (mini < 0)
                            {
                                //Debuter sur table C / Starting with table C
                                if (i == 1)
                                {
                                    functionReturnValue = Strings.Chr(210).ToString();
                                    //Commuter sur table C / Switch to table C
                                }
                                else
                                {
                                    functionReturnValue = functionReturnValue + Strings.Chr(204);
                                }
                                tableB = false;
                            }
                            else
                            {
                                if (i == 1)
                                    functionReturnValue = Strings.Chr(209).ToString();
                                //Debuter sur table B / Starting with table B
                            }
                        }
                        if (!tableB)
                        {
                            //On est sur la table C, essayer de traiter 2 chiffres / We are on table C, try to process 2 digits
                            mini = 2;
                            mini = TestNum(i, mini, inputString);
                            //OK pour 2 chiffres, les traiter / OK for 2 digits, process it
                            if (mini < 0)
                            {
                                dummy = int.Parse(Strings.Mid(inputString, i, 2));
                                dummy = (dummy < 95 ? dummy + 32 : dummy + 105);
                                functionReturnValue = functionReturnValue + Strings.Chr(dummy);
                                i = i + 2;
                                //On n'a pas 2 chiffres, repasser en table B / We haven't 2 digits, switch to table B
                            }
                            else
                            {
                                functionReturnValue = functionReturnValue + Strings.Chr(205);
                                tableB = true;
                            }
                        }
                        if (tableB)
                        {
                            //Traiter 1 caractere en table B / Process 1 digit with table B
                            functionReturnValue = functionReturnValue + Strings.Mid(inputString, i, 1);
                            i = i + 1;
                        }
                    }
                    //Calcul de la cle de controle / Calculation of the checksum
                    for (i = 1; i <= functionReturnValue.Length; i++)
                    {
                        dummy = Strings.Asc(Strings.Mid(functionReturnValue, i, 1));
                        dummy = (dummy < 127 ? dummy - 32 : dummy - 105);
                        if (i == 1)
                            checksum = dummy;
                        checksum = (checksum + (i - 1) * dummy) % 103;
                    }
                    //Calcul du code ASCII de la cle / Calculation of the checksum ASCII code
                    checksum = (checksum < 95 ? checksum + 32 : checksum + 105);
                    //Ajout de la cle et du STOP / Add the checksum and the STOP
                    functionReturnValue = functionReturnValue + Strings.Chr(checksum) + Strings.Chr(211);
                }
            }

            return functionReturnValue;
        }
        private int TestNum(int i, int mini, string inputString)
        {
            //si les mini% caracteres a partir de i% sont numeriques, alors mini%=0
            //if the mini% characters from i% are numeric, then mini%=0
            mini = mini - 1;
            if (i + mini <= Strings.Len(inputString)) {
                while (mini >= 0) {
                    if (Strings.Asc(Strings.Mid(inputString, i + mini, 1)) < 48 | Strings.Asc(Strings.Mid(inputString, i + mini, 1)) > 57)
                        break; // TODO: might not be correct. Was : Exit Do
                    mini = mini - 1;
                }
            }

            return mini;
        }
    }
}