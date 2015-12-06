using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ClientCommon.Classes
{
    /// <summary>
    /// Класс для работы с xml-файлом
    /// </summary>
    public static class XmlFileWorker
    {
        /// <summary>
        /// Загружает объект указанного типа из xml-файла
        /// </summary>
        /// <param name="filePath">
        /// Путь к файлу
        /// </param>
        /// <typeparam name="T">
        /// Тип загружаемого объекта
        /// </typeparam>
        /// <returns>
        /// Загруженный из указанного файла объект
        /// </returns>
        public static T Load<T>(string filePath)
        {
            try
            {
                var formater = new XmlSerializer(typeof(T));
                using (var reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    return (T)formater.Deserialize(reader);
                }
            }
            catch (Exception exception)
            {
                throw new ApplicationException("Возникла ошибка при загрузке файла: " + filePath, exception);
            }
        }

        /// <summary>
        /// Сохраняет указанный объект в файл
        /// </summary>
        /// <param name="filePath">
        /// Путь к файлу
        /// </param>
        /// <param name="value">
        /// Сохраняемый объект
        /// </param>
        /// <typeparam name="T">
        /// Тип объекта
        /// </typeparam>
        public static void Save<T>(string filePath, T value)
        {
            try
            {
                var formater = new XmlSerializer(typeof(T));
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    formater.Serialize(writer, value);
                }
            }
            catch (Exception exception)
            {
                throw new ApplicationException("Возникла ошибка при сохранении файла: " + filePath, exception);
            }
        }
    }
}
