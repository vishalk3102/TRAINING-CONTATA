import React, { useEffect, useState } from 'react'

const Pagination = ({ totalPages, currentPage, onPageChange }) => {
  const [pages, setPages] = useState([])

  useEffect(() => {
    const pageArray = []
    for (let i = 1; i <= totalPages; i++) {
      pageArray.push(i)
    }
    setPages(pageArray)
  }, [totalPages])

  //FUNCTION TO HANDLE PREVIOUS BUTTON CLICK
  const handlePrev = () => {
    onPageChange(currentPage - 1)
  }

  //FUNCTION TO HANDLE NEXT BUTTON CLICK
  const handleNext = () => {
    onPageChange(currentPage + 1)
  }

  return (
    <>
      {' '}
      <div className='w-[100%] h-[100px]  flex justify-center items-center my-10'>
        <ul className='w-[50%]   flex justify-center items-center gap-1'>
          <li
            className='text-[2rem ] font-medium py-2 px-4 bg-blue-400  rounded-sm'
            onClick={handlePrev}
            disabled={currentPage === 1}
          >
            Prev
          </li>
          {pages.map((page, index) => {
            return (
              <li
                key={index}
                className={`text-[2rem ] font-medium py-2 px-4 bg-blue-100 rounded-sm ${
                  currentPage === page ? 'bg-blue-200' : 'bg-blue-100'
                }`}
                onClick={() => onPageChange(page)}
              >
                {page}
              </li>
            )
          })}
          <li
            className='text-[2rem ] font-medium py-2 px-4 bg-blue-400 rounded-sm'
            onClick={handleNext}
            disabled={currentPage === totalPages}
          >
            Next
          </li>
        </ul>
      </div>
    </>
  )
}

export default Pagination
