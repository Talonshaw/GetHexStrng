using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Talon
{
    class DataTypeTransfer
    {
        /// <summary>
        /// 从struct转换到byte[]  
        /// </summary>
        public static byte[] StructToBytes(object structObj)
        {
            //返回类的非托管大小（以字节为单位）  
            int size = Marshal.SizeOf(structObj);

            //分配大小  
            byte[] bytes = new byte[size];

            //从进程的非托管堆中分配内存给structPtr  
            IntPtr structPtr = Marshal.AllocHGlobal(size);

            //将数据从托管对象structObj封送到非托管内存块structPtr  
            Marshal.StructureToPtr(structObj, structPtr, false);

            //Marshal.StructureToPtr(structObj, structPtr, true);  
            //将数据从非托管内存指针复制到托管 8 位无符号整数数组  
            Marshal.Copy(structPtr, bytes, 0, size);

            //释放以前使用 AllocHGlobal 从进程的非托管内存中分配的内存  
            Marshal.FreeHGlobal(structPtr);
            return bytes;
        }
        /// <summary>
        /// 从字节数组转化为结构体  
        /// 
        /// </summary>
        public static StructType ConverBytesToStructure<StructType>(byte[] bytesBuffer)
        {
            // 检查长度  
            int i = Marshal.SizeOf(typeof(StructType));
            if (bytesBuffer.Length != Marshal.SizeOf(typeof(StructType)))
            {
                //throw new ArgumentException("bytesBuffer参数和structObject参数字节长度不一致。");
            }

            //分配一个未托管类型变量  
            IntPtr bufferHandler = Marshal.AllocHGlobal(bytesBuffer.Length);

            //逐个复制，也可以直接用copy()方法  
            for (int index = 0; index < bytesBuffer.Length; index++)
            {
                Marshal.WriteByte(bufferHandler, index, bytesBuffer[index]);
            }

            //从非托管类型转化为托管类型变量  
            StructType structObject = (StructType)Marshal.PtrToStructure(bufferHandler, typeof(StructType));

            //释放非托管类型变量  
            Marshal.FreeHGlobal(bufferHandler);

            return structObject;
        }
        public static sbyte ByteToSbyte(byte a)
        {
            sbyte b;
            if (a < 128)
                b = (sbyte)a;
            else
                b = (sbyte)(a - 256);
            return b;
        }

        /// <summary>
        /// 数字和字节之间互转
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int IntToBitConverter(int num)
        {
            int temp = 0;
            byte[] bytes = BitConverter.GetBytes(num);//将int32转换为字节数组
            temp = BitConverter.ToInt32(bytes, 0);//将字节数组内容再转成int32类型
            return temp;
        }

        /// <summary>
        /// byte[]转为16进制字符串 空格分隔
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ByteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2")+" ";
                }
            }
            return returnStr;
        }
        /// <summary>
        /// 将16进制的字符串转为byte[]
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] HexStrToByte(string hexString)
        {
            if (hexString[hexString.Length-1] == ' ')
                hexString =hexString.Remove(hexString.Length-1);
            string[] datastr = hexString.Split(' ');
            byte[] data = new byte[datastr.Length];
            for (int i = 0; i < datastr.Length; i++)
            {
                data[i] = Convert.ToByte(datastr[i], 16);
            }
            return data;
        }
        
        /// <summary>
        /// 十六进制空格分隔字符串 转 Float
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static float GetFloat(string hexString)
        {
            byte[] data = HexStrToByte(hexString);
            return BitConverter.ToSingle(data, 0);
        }
        public static double GetDouble(string hexString)
        {
            byte[] data = HexStrToByte(hexString);
            return BitConverter.ToDouble(data, 0);
        }
        public static int GetInt(string hexString)
        {
            byte[] data = HexStrToByte(hexString);
            return BitConverter.ToInt32(data, 0);
        }
        public static uint GetUint(string hexString)
        {
            byte[] data = HexStrToByte(hexString);
            return BitConverter.ToUInt32(data, 0);
        }
        public static string GetString(string hexString)
        {
            byte[] data = HexStrToByte(hexString);
            return Encoding.ASCII.GetString(data);
        }
        /// <summary>
        /// 其他类型转十六进制空格分隔字符串
        /// </summary>
        public static string toHexString(float value)
        {
            string hexStr = "";
            byte[] temp = BitConverter.GetBytes(value);
            for (int i = 0; i < temp.Length; i++)
            {
                hexStr += temp[i].ToString("X2") + " ";
            }
            return hexStr;
        }
        public static string toHexString(double value)
        {
            string hexStr = "";
            byte[] temp = BitConverter.GetBytes(value);
            for (int i = 0; i < temp.Length; i++)
            {
                hexStr += temp[i].ToString("X2") + " ";
            }
            return hexStr;
        }
        public static string toHexString(int value)
        {
            string hexStr = "";
            byte[] temp = BitConverter.GetBytes(value);
            for (int i = 0; i < temp.Length; i++)
            {
                hexStr += temp[i].ToString("X2") + " ";
            }
            return hexStr;
        }
        public static string toHexString(uint value)
        {
            string hexStr = "";
            byte[] temp = BitConverter.GetBytes(value);
            for (int i = 0; i < temp.Length; i++)
            {
                hexStr += temp[i].ToString("X2") + " ";
            }
            return hexStr;
        }
        public static string toHexString(string value)
        {
            string hexStr = "";
            byte[] temp = Encoding.ASCII.GetBytes(value);
            for (int i = 0; i < temp.Length; i++)
            {
                hexStr += temp[i].ToString("X2") + " ";
            }
            return hexStr;
        }
    }
}
