# EcsTest
Здесь представлены результаты моего знакомства с платформой LeoEcsLite. Ориентировочные трудозатраты &mdash; 20&nbsp;часов.
## Об игре
Лабиринт с открывающимися дверями. Чтобы открыть дверь, нужно некоторое время постоять на кнопке соответствующего цвета. Управление Point-and-Click.
## Создание уровней
В папке Prefabs лежат элементы для построения уровней:
* Player &mdash; игрок. Камера следует за игроком (Cinemachine FreeLook).
* Wall &mdash; стена. Носит декоративную функцию, коллизии пока не реализованы.
* Door &mdash; открывающаяся дверь. В компоненте Door задается идентификатор двери и время ее открытия (по умолчанию 5 секунд). Также настраивается дочерний трансформ Target, который определяет положение открытой двери. В течение заданного времени открытия дверь плавно перемещается из начального в конечное положение (в том числе возможен поворот двери).
* Button &mdash; кнопка открытия двери. Задаваемый идентификатор должен соответствовать идентификатору двери, которая будет открываться этой кнопкой.
## Системы, не зависящие от клиента
```c#
DoorActivationSystem
EventClearSystem
```
Следующие системы используют UnityEngine только для Vector2/Vector3/Quaternion и теоретически могут быть отвязаны от Unity:
```c#
ButtonTriggerSystem
MovementSystem
PlayerControlSystem
RotationSystem
```
## Системы, привязанные к UnityEngine
```c#
ButtonInitSystem
DoorInitSystem
MouseInputSystem
PlayerAnimationSystem
PlayerInitSystem
RenderingSystem
TimeSystem
```
## GameConfig.cs
Содержит настройки игры (скорость перемещения игрока, цвета дверей и кнопок). Также служит для отсчёта времени. Доступен через механизм SharedData.
## Для связи
ashust@mail.ru<br>TG: @alexandershust