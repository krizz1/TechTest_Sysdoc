const baseUrl = 'https://localhost:44356/api/1/';

export async function  GetProject(id:number)
{ 
  return await getData(`${baseUrl}project/${id}`)
}

export async function  GetProjects()
{ 
  return await getData(`${baseUrl}project`)
}

export async function  GetAction(id:number)
{ 
  return getData(`${baseUrl}action/${id}`)
}

export async function  GetActions()
{ 
  return await getData(`${baseUrl}action`);
}

export async function AddActionToProject(projectId:number, actionId:number)
{ 
  return await patchData(`${baseUrl}project/${projectId}/assignaction/${actionId}`);
}

export async function RemoveActionFromProject(projectId:number, actionId:number)
{ 
  return await deteleData(`${baseUrl}project/${projectId}/unassignaction/${actionId}`);
}

async function getData(url:string)
{
  return await fetch(url,
    {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json'
      }
    }
  )
  .then(async response => await response.json())
  .then(data => { return data; })
  .catch(e => console.error('An issue occurred loading data:', e));
}

async function patchData(url:string)
{
  return await fetch(url,
    {
      method: 'PATCH',
      headers: {
        'Content-Type': 'application/json'
      }
    }
  )
  .then(async response => await response.json())
  .then(data => { return data; })
  .catch(e => console.error('An issue occurred loading data:', e));
}

async function deteleData(url:string)
{
  return await fetch(url,
    {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json'
      }
    }
  )
  .then(async response => await response.json())
  .then(data => { return data; })
  .catch(e => console.error('An issue occurred loading data:', e));
}