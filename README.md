# Microjuego Asteroides

Juego arcade 2D desarrollado en Unity. El jugador controla una nave, esquiva asteroides y los destruye para conseguir la mayor puntuación posible.
## Objetivo

Destruir asteroides y sobrevivir el mayor tiempo posible.

- Cada asteroide destruido concede **100 puntos**.
- La partida termina cuando un asteroide choca con la nave.
- Los asteroides aparecen cada vez con mayor frecuencia.
## Controles

- **Mover:** WASD.
- **Rotar:** left arrow y right arrow en el teclado.
- **Disparar:** barra espaciadora.
## Requisitos

- Unity **6000.6.0f1**.
- Unity Input System.
- TextMeshPro.
- Windows de 64 bits.
## Cómo abrir el proyecto

1. Clonar o descargar el repositorio.
2. Abrir Unity Hub.
3. Seleccionar **Añadir proyecto desde disco**.
4. Elegir la carpeta que contiene `Assets`, `Packages` y `ProjectSettings`.
5. Abrir el proyecto con Unity **6000.6.0f1**.
6. Abrir la escena principal y pulsar **Play**.
## Scripts principales

- `Player.cs`: movimiento, rotación, disparo, puntuación y derrota.
- `Bullet.cs`: movimiento e impacto de las balas.
- `EnemySpawner.cs`: generación de asteroides.

## Autor
**Jorge Muñoa Kaiser**
