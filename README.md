# Sistema de Préstamo de Libros - Biblioteca

## Actividad 2.4 Reestructuración de Vistas con Herencia Gráfica y Polimorfismo en Botones
Equipo 2

## integrantes
Joule Alexander Suñiga Maciel
Ariel Villa Olivares
Marco Antonio Nuñes Martines  

## Descripción
En la actividad 2.2 todas las entidades estaban en una sola ventana. Ahora cada entidad (Usuario, Administrador, Autor, Categoria, Editorial, Libro, Ejemplar, Prestamo, Sancion y Pago) tiene su propio formulario, que hereda de un formulario base. Un formulario principal con botones únicos controla cualquiera de ellos a través de una interfaz, sin saber cuál es.

## Interfaz IPanelCRUD
Es el contrato que cumplen todos los formularios de entidad. Tiene 4 métodos:
- EjecutarGuardar()
- EjecutarBuscar(string id, ErrorProvider alerta)
- EjecutarActualizar()
- EjecutarEliminar(StatusStrip barraEstado)

## Formulario base (FrmBase)
Es la plantilla común. Tiene un panel llamado pnlFormularioBase, con Modifiers en Protected para que los formularios hijos lo puedan heredar, y la caja de texto txtId, donde se captura el Id que todas las entidades heredan de EntidadBase.

## Formularios de las entidades
Cada uno hereda de FrmBase e implementa IPanelCRUD, por ejemplo FrmAutor : FrmBase, IPanelCRUD. Los controles propios de la entidad se acomodan dentro del panel heredado. Los 4 métodos usan el CRUD de los modelos de la 2.3:
- Guardar toma los datos de los controles, crea el objeto y lo guarda en la lista en memoria.
- Buscar consulta por el id y, si lo encuentra, regresa los datos a los controles. Si no existe, lo marca con el ErrorProvider.
- Actualizar reemplaza el registro con los datos de la pantalla y conserva lo que el formulario no edita, como la fecha de registro.
- Eliminar borra el registro y avisa en la barra de estado.

## Formulario principal (FrmPrincipal)
Es la ventana raíz. Tiene un panel central (pnlContenedorVistas) donde se muestra el formulario del módulo que se elige, un campo de búsqueda (txtIdBusqueda), un ErrorProvider, un StatusStrip abajo y los botones btnMasterGuardar, btnMasterBuscar, btnMasterActualizar y btnMasterEliminar.

Tiene una variable private IPanelCRUD vistaActiva. Cuando se elige un módulo, se crea su formulario, se le pone TopLevel = false y FormBorderStyle = None, se mete en el panel con Dock = Fill y se guarda en vistaActiva. Los botones no conocen las clases de los hijos, por ejemplo el de guardar solo llama a vistaActiva.EjecutarGuardar().

## Modelos
Las entidades vienen de la actividad 2.3: heredan de EntidadBase e implementan IAlmacenamientoCRUD. Como todavía no hay base de datos, cada una guarda sus registros en una lista estática en memoria.

## Manejo de errores
Los modelos validan sus datos y lanzan ArgumentException, y el CRUD lanza InvalidOperationException si el id ya existe o no existe. Los formularios capturan esos errores

## Actividad 3.4 Procesos Concurrentes e Hilos de Ejecución
Equipo 2

### Proceso identificado
**Reporte masivo de sanciones por retraso** (menú *Procesos > Reporte masivo de sanciones...*). Analiza hasta 5000 préstamos simulados: calcula los días de retraso con `Prestamo.CalcularDiasRetraso()` y el monto con `Sancion.CalcularMonto()`. Cada registro simula una latencia de acceso a datos (configurable), por lo que el proceso tarda varios segundos.

### Archivos
- `Models/MotorReporteSanciones.cs`: lógica de negocio. No conoce ningún control; solo recibe un `IProgress<T>`, un delegado de filas y un `CancellationToken`.
- `FrmReporteMasivo.cs / .Designer.cs`: vista del proceso (formulario hijo MDI, instancia única).
- `FrmMaestro`: menú *Procesos* que abre la ventana.

### 1. Comportamiento lineal y por qué afecta la experiencia de usuario
El botón **Ejecutar lineal (congela)** corre el mismo motor directamente en el hilo de la interfaz (UI Thread). Ese hilo es el único que procesa los mensajes de Windows (pintar, mouse, teclado); mientras está ocupado en el ciclo no puede atenderlos, por lo que:
- la ventana no se puede mover ni cerrar, y los botones no responden (los clics se acumulan y se ejecutan hasta el final);
- la barra de progreso no se repinta; salta de 0 % a 100 % al terminar;
- no se puede cancelar el proceso;
- Windows marca la ventana como **"No responde"**.

Esto daña la UX porque el usuario no sabe si el sistema trabaja o se descompuso, no tiene control sobre la tarea, tiende a pulsar varias veces o a cerrar el programa a la fuerza (con riesgo de perder trabajo) y percibe el software como inestable aunque el cálculo sea correcto.

### 2. Segundo plano (async/await + Task)
`btnIniciar_Click` es `async void` y llama a `EjecutarEnSegundoPlanoAsync()`, que ejecuta el ciclo pesado únicamente dentro de `await Task.Run(...)`. El hilo de la interfaz queda libre: el **botón de prueba de UI** sigue contando clics mientras el proceso corre.

### 3. Actualización segura de controles
- `ActualizarEstado` (Label) y `AgregarFila` (DataGridView) revisan `InvokeRequired` y usan `BeginInvoke` con una función anónima (`MethodInvoker`) y un delegado (`Action<FilaReporte>`).
- La barra de progreso se actualiza con `Progress<ProgresoReporte>`, creado en el hilo de la UI.
- No se usa `CheckForIllegalCrossThreadCalls = false`.

### 4. Progreso y cancelación
- `ProgressBar.Value` sigue el porcentaje real del ciclo (se reporta cada 1 %).
- El botón **Detener** llama a `CancellationTokenSource.Cancel()`; el motor revisa el `CancellationToken` en cada registro y termina el ciclo de forma ordenada devolviendo el avance parcial (`Cancelado = true`), sin lanzar excepciones. También se cancela si se cierra la ventana con el proceso activo.
