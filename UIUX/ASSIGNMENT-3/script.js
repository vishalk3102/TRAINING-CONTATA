$(document).ready(function () {
  // ADD DETAILS TO TABLE
  $('#form').submit(handleSubmit)

  // DELETE DETAILS FROM TABLE
  $(document).on('click', '.btn-delete', handleDelete)

  // EDIT  DETAILS OF TABLE
  $(document).on('click', '.btn-edit', handleEdit)
})

// FUNCTION TO HANDLE SUBMIT BUTTON FUNCTIONALITY
function handleSubmit (e) {
  e.preventDefault()
  var fullName = $('#fullname').val()
  var empCode = $('#empcode').val()
  var salary = $('#salary').val()
  var city = $('#city').val()

  var newRow = ` <tr>
    <td>${fullName}</td>
    <td>${empCode}</td>
    <td>${salary}</td>
    <td>${city}</td>
    <td style="display:flex; justify-content:center;"><button class="btn-edit" style="background-color:green;">Edit</button> <button class="btn-delete" style="background-color:red;">Delete</button></td>
    </tr>`

  $('#table tbody').append(newRow)
  $('#form')[0].reset()
}

// FUNCTION TO HANDLE DELETE BUTTON FUNCTIONALITY
function handleDelete () {
  $(this).closest('tr').remove()
  console.log('deleted')
}

// FUNCTION TO HANDLE EDIT BUTTON FUNCTIONALITY
function handleEdit () {
  var currentRow = $(this).closest('tr')
  var fullName = currentRow.find('td:eq(0)').text()
  var empCode = currentRow.find('td:eq(1)').text()
  var salary = currentRow.find('td:eq(2)').text()
  var city = currentRow.find('td:eq(3)').text()

  $('#fullname').val(fullName)
  $('#empcode').val(empCode)
  $('#salary').val(salary)
  $('#city').val(city)
  currentRow.remove()
}
