# Tic-Tac-Toe (XO) Game

An interactive, desktop-based Tic-Tac-Toe game created with C# and Windows Forms, focusing on event-driven logic, game state machines, and visual feedback.

---

## Key Features

* **Interactive Game Board:** A clean 3x3 grid using modern custom visual assets for X and O indicators.
* **Turn Switching Logic:** Automatic switching between Player 1 and Player 2 with a dynamic text header indicating the active turn or game status.
* **Win/Draw Detection:** Built-in algorithms that instantly analyze rows, columns, and diagonals after each move to declare a winner or a draw.
* **Game Over Visuals:** Displays the final state clearly, highlighting the winner (e.g., Player 1) and freezing inputs once a match finishes.
* **Restart Functionality:** A single-click "Restart Game" button to safely reset the matrix, clear scores, and begin a new session.

---

## Technical Stack and Concepts

* **C# Windows Forms:** Designed with functional button arrays, dynamic picture switching, and label styling.
* **Matrix Logic:** Employs background multi-dimensional tracking arrays to handle game positions and logical validation.
* **Event-Driven Programming:** Leverages unified event click handlers for smooth grid interaction and responsive UI rendering.
