@if(!string.IsNullOrEmpty(item.Reason))
 {
     < button  asp - controller = "Admin" asp - action = "UnfreezeForm" className = 'text-[14px] font-medium bg-blue-400 outline-none py-2 px-4 rounded m-1' > Unfreeze </ button >
     < button  asp - controller = "Admin" asp - action = "AcceptForm" className = 'text-[14px] font-medium bg-green-400 outline-none py-2 px-4 rounded m-1' > Accept </ button >
     < button  asp - controller = "Admin" asp - action = "RejectForm" className = 'text-[14px] font-medium bg-red-400 outline-none py-2 px-4 rounded m-1' > Reject </ button >
 }
 < button  asp - controller = "Admin" asp - action = "AcceptForm" className = 'text-[14px] font-medium bg-green-400 outline-none py-2 px-4 rounded m-1' > Accept </ button >
 < button  asp - controller = "Admin" asp - action = "RejectForm" className = 'text-[14px] font-medium bg-red-400 outline-none py-2 px-4 rounded m-1' > Reject </ button >