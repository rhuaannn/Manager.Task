namespace Manager.Task.Api.Controllers
{
    using AutoMapper;
    using Manager.Task.Application.Interfaces;
    using Manager.Task.Domain.DTO;
    using Manager.Task.Domain.Task;
    using Microsoft.AspNetCore.Mvc;

        [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
                private readonly ITask _taskService;

                private readonly IMapper _mapper;

        public TaskController(ITask taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

                [HttpGet]
        [ProducesResponseType(typeof(TaskResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {

            var tasks = await _taskService.GetTaskAllAsync();
            var taskDtos = _mapper.Map<IEnumerable<TaskResponseDto>>(tasks);
            return Ok(taskDtos);
        }

                [HttpPost]
        [ProducesResponseType(typeof(TaskResponseDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] TaskDto taskDto)
        {
            var task = _mapper.Map<ManagerTask>(taskDto);
            var createTask = await _taskService.CreateTaskAsync(task);
            var TaskResponseDto = _mapper.Map<TaskResponseDto>(createTask);
            return CreatedAtAction(nameof(GetTaskById), new { id = TaskResponseDto.Id }, TaskResponseDto);
        }

                [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(TaskResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            var taskDto = _mapper.Map<TaskResponseDto>(task);
            return Ok(taskDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var task = await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTaskAsync([FromBody] TaskDto taskDto )
        { 
            var task = _mapper.Map<ManagerTask>(taskDto);
            var updatedTask = await _taskService.UpdateTaskAsync(task);
            return Ok(updatedTask);
        }
    }
}
