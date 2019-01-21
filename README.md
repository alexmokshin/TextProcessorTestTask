# TextProcessor
Данный проект выполнен в рамках тестового задания.

# Правила использования
Данное приложение предназначено для автодополнения части слова.
Алгоритм работы программы в режиме ввода: пользователь вводит слово или часть слова, 
нажимает Enter и автоматически получает список подходящих слов, которые соответствуют
логике «автодополнения». После этого приложение вновь переходит в ожидание ввода. Цикл
таких «запросов» повторяется до тех пор, пока пользователь не введет пустую строку.

Список слов «автодополнения» должен удовлетворяет следующим требованиям:
1. Количество слов, включаемых в список подходящих, не должен превышать 5;
2. Выбор подходящих слов исходит из условия наиболее «частых» слов в словаре;
3. Выборка подходящих слов сортируется в порядке убывания частоты;
4. В случае совпадения частот слова сортируются по алфавиту;
5. Вывод списка разделяется переводом строки для каждого подходящего слова.

Пример выполнения автодополнения текста представлен на рисунке:
![Image alt](https://github.com/alexmokshin/TextProcessorTestTask/raw/master/TextProcessor/Images/auto_complete_words.PNG)

# Режим работы приложения при существующих аргументах командной строки
Для менеджмента словаря, возможно использовать аргументы командной строки. В текущей реализации, приложение поддерживает
3 типа команд:
1. CREATE - создание словаря, и наполнение его текстом из файла
2. DELETE - очистка словаря
3. ADD - дополнение текста к текущему словарю
Команды CREATE и ADD, в свою очередь, требуют, в качестве второго аргумента командной строки путь к файлу.

Ниже представлена команда для дополнения словаря:
![Image alt](https://github.com/alexmokshin/TextProcessorTestTask/raw/master/TextProcessor/Images/fill_database.PNG)

Ниже представлена команда для очистки словаря:
![Image alt](https://github.com/alexmokshin/TextProcessorTestTask/raw/master/TextProcessor/Images/clean_database.PNG)

