module User.Domain

open System

type User =
  { id: Guid
    username: string
    firstName: string
    lastNAme: string
    password: string
    email: string
    created_at: DateTime
    updated_at: DateTime
    profile_image: string }

type UsersFetcher = string -> User list
