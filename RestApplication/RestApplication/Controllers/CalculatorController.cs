using Microsoft.AspNetCore.Mvc;

namespace RestApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
       
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Subtracao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = Convert.ToDecimal(firstNumber) - Convert.ToDecimal(secondNumber);
                return Ok(sub.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplicacao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mult = Convert.ToDecimal(firstNumber) * Convert.ToDecimal(secondNumber);
                return Ok(mult.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Divisao(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var div = Convert.ToDecimal(firstNumber) / Convert.ToDecimal(secondNumber);
                return Ok(div.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}/{thirdNumber}")]
        public IActionResult Media(string firstNumber, string secondNumber, string thirdNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && IsNumeric(thirdNumber))
            {           
                var media = (Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber) + Convert.ToDecimal(thirdNumber)) / 3; 

                return Ok(media.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("raiz/{number}")]
        public IActionResult Raiz(string number)
        {
            if (IsNumeric(number))
            {
                return Ok(TemRaizQuadradaExata(Convert.ToInt32(number)).ToString());
            }

            return BadRequest("Invalid Input");
        }

        private int TemRaizQuadradaExata(int numero)
        {
            if (numero < 0) return 0; // números negativos não possuem raiz quadrada real
            double raiz = Math.Sqrt(numero);
            int raizInteira = (int)Math.Round(raiz);
            return raizInteira ;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;

            return double.TryParse(strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
        }
    }
}