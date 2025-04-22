using System;
using System.Text;

namespace Ex01_01
{
				class Program
				{
								private const int k_BinaryInputCount = 4;
								private const int k_BinaryLength = 7;

								public static void Main()
								{
												Console.WriteLine("Please enter 4 binary numbers of 7 digits each:");

												string[] binaryInputArray = new string[k_BinaryInputCount];

												for (int binaryIndex = 0; binaryIndex < k_BinaryInputCount; binaryIndex++)
												{
																binaryInputArray[binaryIndex] = GetValidBinaryInput();
												}

												int[] decimalValuesArray = ConvertBinaryArrayToDecimal(binaryInputArray);

												Console.WriteLine();
												Console.WriteLine("Sorted decimal values (descending):");
												PrintSortedDescending(decimalValuesArray);

												Console.WriteLine();
												PrintAverage(decimalValuesArray);

												Console.WriteLine();
												PrintLongestOnesSequence(binaryInputArray);

												Console.WriteLine();
												PrintBitTransitions(binaryInputArray);

												Console.WriteLine();
												PrintStatisticsOfOneBits(binaryInputArray);
								}

								public static string GetValidBinaryInput()
								{
												string userInput = Console.ReadLine();
												bool isValidBinary = IsValidBinaryString(userInput, k_BinaryLength);

												while (!isValidBinary)
												{
																Console.WriteLine("Invalid input. Please enter a 7-digit binary number:");
																userInput = Console.ReadLine();
																isValidBinary = IsValidBinaryString(userInput, k_BinaryLength);
												}

												return userInput;
								}

								public static bool IsValidBinaryString(string binaryString, int expectedLength)
								{
												if (binaryString.Length != expectedLength)
												{
																return false;
												}

												foreach (char character in binaryString)
												{
																if (!Char.IsDigit(character) || (character != '0' && character != '1'))
																{
																				return false;
																}
												}

												return true;
								}

								public static int[] ConvertBinaryArrayToDecimal(string[] binaryStrings)
								{
												int[] convertedDecimalArray = new int[binaryStrings.Length];

												for (int index = 0; index < binaryStrings.Length; index++)
												{
																convertedDecimalArray[index] = ConvertBinaryToDecimal(binaryStrings[index]);
												}

												return convertedDecimalArray;
								}

								public static int ConvertBinaryToDecimal(string binaryString)
								{
												int decimalValue = 0;

												for (int bitIndex = 0; bitIndex < binaryString.Length; bitIndex++)
												{
																if (binaryString[bitIndex] == '1')
																{
																				int power = binaryString.Length - 1 - bitIndex;
																				decimalValue += (int)Math.Pow(2, power);
																}
												}

												return decimalValue;
								}

								public static void PrintSortedDescending(int[] decimalNumbers)
								{
												int totalNumbers = decimalNumbers.Length;

												for (int stepOfSorting = 0; stepOfSorting < totalNumbers - 1; stepOfSorting++)
												{
																for (int elementIndex = 0; elementIndex < totalNumbers - stepOfSorting - 1; elementIndex++)
																{
																				bool shouldSwap = decimalNumbers[elementIndex] < decimalNumbers[elementIndex + 1];

																				if (shouldSwap)
																				{
																								int temp = decimalNumbers[elementIndex];
																								decimalNumbers[elementIndex] = decimalNumbers[elementIndex + 1];
																								decimalNumbers[elementIndex + 1] = temp;
																				}
																}
												}

												Console.WriteLine(BuildSpaceSeparatedString(decimalNumbers));
								}

								private static string BuildSpaceSeparatedString(int[] numbers)
								{
												StringBuilder builder = new StringBuilder();

												foreach (int number in numbers)
												{
																builder.Append(number);
																builder.Append(' ');
												}

												return builder.ToString().TrimEnd();
								}

								public static void PrintAverage(int[] numbersToAverage)
								{
												int sum = 0;

												foreach (int number in numbersToAverage)
												{
																sum += number;
												}

												double average = (double)sum / numbersToAverage.Length;
												Console.WriteLine(string.Format("Average: {0:F2}", average));
								}

								public static void PrintLongestOnesSequence(string[] binaryInputArray)
								{
												int maxStreak = 0;
												string binaryWithMaxStreak = "";

												foreach (string binaryString in binaryInputArray)
												{
																int currentStreak = 0;
																int localMax = 0;

																foreach (char bit in binaryString)
																{
																				if (bit == '1')
																				{
																								currentStreak++;
																								localMax = Math.Max(localMax, currentStreak);
																				}
																				else
																				{
																								currentStreak = 0;
																				}
																}

																if (localMax > maxStreak)
																{
																				maxStreak = localMax;
																				binaryWithMaxStreak = binaryString;
																}
												}

												Console.WriteLine(string.Format("Longest sequence of consecutive 1s is {0} in {1}", maxStreak, binaryWithMaxStreak));
								}

								public static void PrintBitTransitions(string[] binaryInputArray)
								{
												Console.WriteLine("Number of bit transitions (0 <-> 1):");

												foreach (string binary in binaryInputArray)
												{
																int transitionCount = 0;

																for (int position = 0; position < binary.Length - 1; position++)
																{
																				if (binary[position] != binary[position + 1])
																				{
																								transitionCount++;
																				}
																}

																Console.WriteLine(string.Format("{0} → {1} transitions", binary, transitionCount));
												}
								}

								public static void PrintStatisticsOfOneBits(string[] binaryInputArray)
								{
												int totalOneBits = 0;
												int maxOneBits = 0;
												string binaryWithMaxOnes = "";

												foreach (string binary in binaryInputArray)
												{
																int currentOneBits = CountOneBits(binary);
																totalOneBits += currentOneBits;

																if (currentOneBits > maxOneBits)
																{
																				maxOneBits = currentOneBits;
																				binaryWithMaxOnes = binary;
																}
												}

												int decimalValue = ConvertBinaryToDecimal(binaryWithMaxOnes);

												Console.WriteLine(string.Format("Binary with most '1' bits: {0} ({1} ones)", binaryWithMaxOnes, maxOneBits));
												Console.WriteLine(string.Format("Decimal value: {0}", decimalValue));
												Console.WriteLine(string.Format("Total number of '1' bits: {0}", totalOneBits));
								}

								public static int CountOneBits(string binaryString)
								{
												int oneBitCounter = 0;

												foreach (char currentChar in binaryString)
												{
																if (Char.IsDigit(currentChar) && currentChar == '1')
																{
																				oneBitCounter++;
																}
												}

												return oneBitCounter;
								}
				}
}